using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

    public SelectList PetList { get; set; }
    public SelectList HealthPlanList { get; set; }

    //List
    public string Pet { get; set; }
    public string HealhPlan { get; set; }
    public string ExternalId { get; set; }
    public bool IsRecurrence { get; set; }
    public int Installments { get; set; }
    public DateTime? LastPayment { get; set; }

    public static List<PaymentVM> ToList(List<Domain.Models.Payment> payments)
    {
        return payments.Select(x => new PaymentVM
        {
            Id = x.Id,
            PetId = x.PetId,
            HealthPlanId = x.HealthPlanId,
            ExternalId = x.ExternalId,
            IsRecurrence = x.IsRecurrence,
            Installments = x.Installments,
            LastPayment = x.LastPayment,
            Pet = x.Pet.Name,
            HealhPlan = x.HealthPlan.Name
        }).ToList();
    }
}

public class PaymentCardVM
{
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
    public int? ExpirationMonth { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Ano de expiração")]
    [MaxLength(2, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [MinLength(2, ErrorMessage = ValidationKeysUtil.SizeMin)]
    public int? ExpirationYear { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Código de segurança")]
    [MaxLength(4, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [MinLength(3, ErrorMessage = ValidationKeysUtil.SizeMin)]
    public string Cvv { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Bandeira")]
    public CardBrand? Brand { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Recorrência (meses)")]
    public int? Installments { get; set; }

    public SelectList BrandList { get; set; }

    public CardDTO ToDTO()
    {
        return new CardDTO(Number, HolderName, ExpirationMonth.Value, ExpirationYear.Value, Cvv, Brand.Value, Installments.Value);
    }
}

public class PaymentBillingAddressVM
{
    [DisplayName("Endereço de cobrança direfente do endereço do tutor?")]
    [ValidateNever]
    public bool HasBillingAddress { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Endereço")]
    public string Address { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Cidade")]
    public string City { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [StringLength(2, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [DisplayName("Estado")]
    public string State { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [StringLength(2, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [DisplayName("País")]
    public string Country { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [StringLength(8, ErrorMessage = ValidationKeysUtil.SizeMax)]
    [DisplayName("Código Postal (CEP)")]
    public string ZipCode { get; set; }

    public BillingAddressDTO? ToDTO()
    {
        if (!HasBillingAddress)
            return null;

        return new BillingAddressDTO(Address, City, State, Country, ZipCode);
    }
}
