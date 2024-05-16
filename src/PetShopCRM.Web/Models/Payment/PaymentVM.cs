using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Emit;

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
    public string HealhPlan { get; set; }
    public string ExternalId { get; set; }
    public string ExternalIdUrl { get; set; }
    public bool IsRecurrence { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsActive { get; set; }
    public int Installment { get; set; }
    public DateTime? FirstPayment { get; set; }
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
            Installment = x.Installment,
            FirstPayment = x.FirstPayment,
            LastPayment = x.LastPayment,
            IsSuccess = x.IsSuccess,
            IsActive = x.Active,
            Pet = $"{x.Pet.Identifier} - {x.Pet.Name} - {x.Guardian.Name}",
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

    public CardDTO ToDTO()
    {
        return new CardDTO(Number, HolderName, ExpirationMonth, ExpirationYear, Cvv, Brand.Value);
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
    [DisplayName("Estado")]
    public string State { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("País")]
    public string Country { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Código Postal (CEP)")]
    public string ZipCode { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Bairro")]
    public string Neighborhood { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Complemento")]
    public string Unit { get; set; }

    [RequiredIfTrue(nameof(HasBillingAddress), ErrorMessage = ValidationKeysUtil.Required)]
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

    [RequiredIfTrue(nameof(HasCustomer), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [RequiredIfTrue(nameof(HasCustomer), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("CPF")]
    public string CPF { get; set; }

    [RequiredIfTrue(nameof(HasCustomer), ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Telefone")]
    public string Phone { get; set; }

    [RequiredIfTrue(nameof(HasCustomer), ErrorMessage = ValidationKeysUtil.Required)]
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