using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Domain.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using PetShopCRM.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace PetShopCRM.Web.Models.Guardian;

public class GuardianVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Data de Nascimento")]
    public string DateBirth { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [Remote("GuardianCpfExists", "Validation", AdditionalFields = "Id", ErrorMessage = ValidationKeysUtil.ValidateCPF)]
    [DisplayName("CPF")]
    public string CPF { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Telefone")]
    public string Phone { get; set; }

    [EmailAddress(ErrorMessage = ValidationKeysUtil.Email)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Endereço")]
    public string Address { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Pais")]
    public string Country { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Estado")]
    public string State { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Cidade")]
    public string City { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("CEP")]
    public string CEP { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Bairro")]
    public string Neighborhood { get; set; }

    [DisplayName("Complemento")]
    public string? Unit { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Número")]
    public string Number { get; set; }



    public List<GuardianVM> ToList(List<Domain.Models.Guardian> listGuardian)  =>listGuardian.Select(guardian => new GuardianVM
        {
            Name = guardian.Name,
            Address = guardian.Address,
            CPF = guardian.CPF,
            DateBirth = guardian.DateBirth,
            Id = guardian.Id,
            Phone = guardian.Phone,
            CEP = guardian.CEP,
            Country = guardian.Country,
            State = guardian.State,
            City = guardian.City,
            Neighborhood = guardian.Neighborhood,
            Email = guardian.Email, 
            Unit = guardian.Unit,
            Number = guardian.Number,
        }).ToList();

    public Domain.Models.Guardian ToModel() => new Domain.Models.Guardian() { Id = this.Id, Name = this.Name, Address = this.Address, CPF = this.CPF, DateBirth = this.DateBirth, Phone = this.Phone, CEP = this.CEP, Country = this.Country, State = this.State, City = this.City, Neighborhood = this.Neighborhood, Email = this.Email, Unit = this.Unit, Number = this.Number };

    public Domain.Models.User ToModelUser()
    {
        var cpf = this.CPF.Replace(".", "").Replace("-", "");

        var user = new Domain.Models.User()
        {
            Name = this.Name, CPF = this.CPF, Email = this.Email,  Type = UserType.Guardian, Phone = this.Phone, Login = cpf, Password = "vetcard123"

        };
        return user;
    }


    public GuardianVM ToVM(Domain.Models.Guardian model) => new GuardianVM { Id = model.Id, Name = model.Name, Address = model.Address, CPF = model.CPF, DateBirth = model.DateBirth, Phone = model.Phone, CEP = model.CEP, Country = model.Country, State = model.State, City = model.City, Neighborhood = model.Neighborhood , Email = model.Email, Unit = model.Unit , Number = model.Number };
    

}
