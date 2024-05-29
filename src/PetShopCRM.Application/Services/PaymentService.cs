using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Payments;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System.Globalization;

namespace PetShopCRM.Application.Services;

public class PaymentService(
    IUnitOfWork unitOfWork, 
    IPagarMeService pagarMeService, 
    IEmailService emailService,
    IWebContext webContext) : IPaymentService
{
    public Payment? GetById(int id)
    {
        return unitOfWork.PaymentRepository.GetBy(x => x.Id == id)
            .Include(x => x.HealthPlan)
            .FirstOrDefault();
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        var payments = unitOfWork.PaymentRepository.GetBy().ToList();

        return payments;
    }

    public async Task<ResponseDTO<List<Payment>>> GetAllCompleteAsync(int idPet = 0)
    {
        var payments = unitOfWork.PaymentRepository.GetBy()
            .Include(x => x.Guardian)
            .Include(x => x.Pet)
                .ThenInclude(x => x.Specie)
            .Include(x => x.HealthPlan)
            .Where(c => c.IsSuccess || c.ExternalId == null)
            .AsQueryable();

        if (idPet != 0)
            payments = payments.Where(c => c.PetId == idPet);

        return new ResponseDTO<List<Payment>>(payments.ToList().Count > 0, "Nenhum resultado encontrado", payments.ToList());
    }

    public async Task<ResponseDTO<Payment?>> AddOrUpdateAsync(int petId, int healthPlanId, int? paymentId = null, CardDTO? card = null, BillingAddressDTO? billingAddress = null, CustomerDTO? customer = null)
    {
        try
        {
            var guardian = await unitOfWork.GuardianRepository.GetByPetIdAsync(petId);
            var healthPan = await unitOfWork.HealthPlansRepository.GetByIdAsync(healthPlanId);
            var pet = await unitOfWork.PetRepository.GetByIdAsync(petId);

            Payment? payment = null;

            if (paymentId.HasValue && paymentId != 0)
                payment = await unitOfWork.PaymentRepository.GetByIdAsync(paymentId.Value);
            
            if (!paymentId.HasValue || payment == null)
                payment = new Payment
                {
                    GuardianId = guardian.Id,
                    PetId = pet.Id,
                    HealthPlanId = healthPan.Id,
                    IsRecurrence = true,
                    Installment = 0
                };

            if (card != null)
            {
                var paymentResponse = pagarMeService.GenerateRecurrence(guardian, healthPan, card, billingAddress, customer);

                if (paymentResponse != null)
                {
                    payment.ExternalId = paymentResponse.Id;
                    payment.FirstPayment = DateTime.Now;
                    payment.LastPayment = DateTime.Now;
                    payment.IsSuccess = paymentResponse.Status.Equals("active", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    return new ResponseDTO<Payment?>(false, Resources.Message.PaymentIntegrationFailed, null);
                }
            }

            await unitOfWork.PaymentRepository.AddOrUpdateAsync(payment);
            await unitOfWork.SaveChangesAsync();

            if (string.IsNullOrEmpty(payment.ExternalId))
                await SendCheckoutEmail(guardian, healthPan, pet, payment);
            else
                await SendPayablePlanEmail(guardian, healthPan);

            return new ResponseDTO<Payment?>(true, string.Empty, payment);
        }
        catch (Exception ex)
        {
            return new ResponseDTO<Payment?>(false, ex.Message, null);
        }
    }

    public string GenerateWebhookUrl()
    {
        return webContext.GenerateUrl("Payment", "Webhook");
    }

    public async Task UpdateLastPaymentDateAndInstallmentAsync(int id, DateTime date)
    {
        var payment = await unitOfWork.PaymentRepository.GetByIdAsync(id);

        if(payment != null)
        {
            payment.LastPayment = date;
            payment.Installment++;

            await unitOfWork.PaymentRepository.AddOrUpdateAsync(payment);
            await unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<bool> CancelAsync(int id)
    {
        var payment = await unitOfWork.PaymentRepository.GetByIdAsync(id);

        if (payment == null) return false;

        var result = pagarMeService.CancelSubscription(payment.ExternalId);

        var deleted = await unitOfWork.PaymentRepository.DeleteOrRestoreAsync(payment.Id);
        await unitOfWork.SaveChangesAsync();

        return result != null && deleted;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await unitOfWork.PaymentRepository.DeletePermanentAsync(id);
        await unitOfWork.SaveChangesAsync();

        return deleted;
    }

    public decimal GetValue()
    {
        var response = pagarMeService.GetAvailableValues();

        var value = response?.AvailableAmount?.ToString("0000") ?? "0000";

        _ = decimal.TryParse(value[..^2] + "," + value[^2..], NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out decimal parsedValue);
        return parsedValue;
    } 


    public PlanDateCreateDTO GetPlanByPet(int id)
    {
        var payments = unitOfWork.PaymentRepository.GetBy();
        var planDateCreateDTO = payments.Where(c => c.PetId == id && c.IsSuccess && c.Active).Select(c => new PlanDateCreateDTO(c.HealthPlanId, c.CreatedDate)).First();

        return planDateCreateDTO;
}
    private async Task SendPayablePlanEmail(Guardian guardian, HealthPlan healthPlan)
    {
        await emailService.SendAsync(guardian.Email, "Bem vindo ao Plano de Saúde Pet VetCard.", $"<p>Prezado(a) {guardian.Name},<p>Esperamos que você e seu amado pet estejam bem.<p>É com grande satisfação que informamos que a compra do plano de saúde para o seu pet foi realizada com sucesso! Agradecemos pela confiança em nossos serviços e estamos felizes em tê-lo como nosso cliente.<p><strong>Detalhes do Plano Adquirido:</strong><ul><li><strong>Plano:</strong> {healthPlan.Name}</ul><p>Para visualizar todos os benefícios que o seu plano oferece, por favor, clique <a href=http://vetcard.com.br/ >aqui</a>.<p>Caso tenha alguma dúvida ou necessite de assistência, não hesite em entrar em contato conosco. Estamos à disposição para ajudar no que for necessário.<p>Mais uma vez, agradecemos pela sua compra e esperamos que você e seu pet tenham uma excelente experiência com o VetCard.<p>Atenciosamente,<p>Equipe VetCard", true);
    }

    private async Task SendCheckoutEmail(Guardian guardian, HealthPlan healthPlan, Pet pet, Payment payment)
    {
        var checkoutUrl = webContext.GenerateUrl("Payment", "Checkout") + $"?refId={payment.Id.EncryptNumberAsBase64()}";

        await emailService.SendAsync(guardian.Email, "Plano de Saúde Pet VetCard.", $"<hr><div><center><div><p style=text-align:center><strong><a href={checkoutUrl} style=background-color:#396;color:#fff;padding:5px;border-radius:5px>ACESSAR O CHECKOUT</a></strong></div></center></div><hr><p>Prezado(a) {guardian.Name},<p>Esperamos que você e seu amado pet estejam bem.<p>Agradecemos pela confiança em nossos serviços e estamos felizes em tê-lo como nosso cliente.<p><strong>Detalhes do Plano solicitado:</strong><ul><li><strong>Plano:</strong> {healthPlan.Name}<li><strong>Valor:</strong> R$ {healthPlan.Value.ToString("#,###.##").Replace(',', '!').Replace('.', ',').Replace('!', '.')}<li><strong>Pet:</strong> {pet.Name}</ul><p><strong>Acesse a página de checkout para realizar o pagamento: <a href={checkoutUrl}>aqui</a></strong><p>Para visualizar todos os benefícios que o seu plano oferece, por favor, clique <a href=http://vetcard.com.br/ >aqui</a>.<p>Caso tenha alguma dúvida ou necessite de assistência, não hesite em entrar em contato conosco. Estamos à disposição para ajudar no que for necessário.<p>Mais uma vez, agradecemos pela sua compra e esperamos que você e seu pet tenham uma excelente experiência com o VetCard.<p>Atenciosamente,<p>Equipe VetCard", true);

    }
}
