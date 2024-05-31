using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PetShopCRM.Web.Models.Payment;

public class PaymentVM
{
    //Form
    public int Id { get; set; }
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Pet")]
    public int PetId { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Plano de saúde")]
    public int HealthPlanId { get; set; }

    public PaymentCardVM Card { get; set; }
    public PaymentBillingAddressVM BillingAddress { get; set; }
    public PaymentCustomerVM Customer { get; set; }

    public SelectList PetList { get; set; }
    public SelectList HealthPlanList { get; set; }

    //List
    public string Pet { get; set; }
    public string GuardianPhoneMessage { get; set; }
    public string HealhPlan { get; set; }
    public string ExternalId { get; set; }
    public string ExternalIdUrl { get; set; }
    public bool IsRecurrence { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsActive { get; set; }
    public int Installment { get; set; }
    public DateTime? FirstPayment { get; set; }
    public DateTime? LastPayment { get; set; }

    public static List<PaymentVM> ToList(List<Domain.Models.Payment> payments, IWebContext webContext)
    {
        return payments.Select(x => new PaymentVM
        {
            Id = x.Id,
            PetId = x.PetId,
            HealthPlanId = x.HealthPlanId,
            ExternalId = x.ExternalId,
            IsRecurrence = x.IsRecurrence,
            Installment = x.Installment,
            FirstPayment = x.FirstPayment,
            LastPayment = x.LastPayment,
            IsSuccess = x.IsSuccess,
            IsActive = x.Active,
            Pet = $"{x.Pet.Identifier} - {x.Pet.Name} - {x.Guardian.Name}",
            HealhPlan = x.HealthPlan.Name,
            GuardianPhoneMessage = $"https://api.whatsapp.com/send?phone={"55" + Regex.Replace(x.Guardian.Phone, @"\D", "")}&text=Ol%C3%A1%20{x.Guardian.Name},%20%0AEsperamos%20que%20esteja%20tudo%20bem%20com%20voc%C3%AA!%0ATe%20enviamos%20no%20e-mail:%20{x.Guardian.Email},%20o%20link%20para%20continuar%20o%20pagamento%20do%20plano%20de%20sa%C3%BAde%20VetCard.%0ACaso%20n%C3%A3o%20tenha%20visto,%20basta%20clicar%20no%20link%20abaixo%20para%20acessar.%0A{webContext.GenerateUrl("Payment", "Checkout")}?refId={x.Id.EncryptNumberAsBase64()}%0A%0AAgradecemos%20sua%20colabora%C3%A7%C3%A3o%20e%20estamos%20%C3%A0%20disposi%C3%A7%C3%A3o%20para%20qualquer%20d%C3%BAvida.%0A%0AAtenciosamente,%C2%A0VetCard."
        }).ToList();
    }
}

public class PaymentCardVM
{
    [DisplayName("Deseja preencher os dados do cartão? (Caso 'Não', envia link para o tutor)")]
    [ValidateNever]
    public bool HasCard { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Número do cartao")]
    public string Number { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome impresso")]
    public string HolderName { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Mês de expiração")]
    [MaxLength(2, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [MinLength(2, ErrorMessage = ValidationKeysUtil.SizeMin)]
    public string ExpirationMonth { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Ano de expiração")]
    [MaxLength(2, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [MinLength(2, ErrorMessage = ValidationKeysUtil.SizeMin)]
    public string ExpirationYear { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Código de segurança")]
    [MaxLength(4, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [MinLength(3, ErrorMessage = ValidationKeysUtil.SizeMin)]
    public string Cvv { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Bandeira")]
    public CardBrand? Brand { get; set; }

    public SelectList BrandList { get; set; }

    public CardDTO? ToDTO()
    {
        if (!HasCard)
            return null;

        return new CardDTO(Number, HolderName, ExpirationMonth, ExpirationYear, Cvv, Brand.Value);
    }
}

public class PaymentBillingAddressVM
{
    [DisplayName("Endereço de cobrança direfente do endereço do tutor?")]
    [ValidateNever]
    public bool HasBillingAddress { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Endereço")]
    public string Address { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Cidade")]
    public string City { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Estado")]
    public string State { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("País")]
    public string Country { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Código Postal (CEP)")]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Bairro")]
    public string Neighborhood { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Complemento")]
    public string Unit { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Número")]
    public string Number { get; set; }


    public BillingAddressDTO? ToDTO()
    {
        if (!HasBillingAddress)
            return null;

        return new BillingAddressDTO(Address, City, State, Country, ZipCode, Unit, Neighborhood, Number);
    }
}

public class PaymentCustomerVM
{
    [DisplayName("Informações pessoais diferentes do tutor?")]
    [ValidateNever]
    public bool HasCustomer { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("CPF")]
    public string CPF { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Telefone")]
    public string Phone { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [EmailAddress(ErrorMessage = ValidationKeysUtil.Email)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    public CustomerDTO? ToDTO()
    {
        if (!HasCustomer)
            return null;

        return new CustomerDTO(Name, CPF, Phone, Email);
    }

}