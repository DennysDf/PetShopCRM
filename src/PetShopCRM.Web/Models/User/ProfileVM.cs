using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.DTOs.User;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models.User;

public class ProfileVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Remote("ValidatePassword", "User",ErrorMessage = ValidationKeysUtil.ValidatePassword)]
    [DisplayName("Senha")]
    public string? Password { get; set; }

    [MinLength(6, ErrorMessage = ValidationKeysUtil.SizeMin)]
    [DisplayName("Nova senha")]
    public string? PasswordNew { get; set; }

    [Compare(nameof(PasswordNew), ErrorMessage = ValidationKeysUtil.ComparePassword)]
    [DisplayName("Confirmar senha")]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [EmailAddress(ErrorMessage = ValidationKeysUtil.Email)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [DisplayName("Telefone")]
    public string? Phone { get; set; }
    public IFormFile? Photo { get; set; }
    public string? NamePhoto { get; set; }

    public void ToViewModel(Domain.Models.User model)
    {
        Name = model.Name;
        Password = model.Password;
        Email = model.Email;
        Phone = model.Phone;
    }

    public ProfileDTO ToDTO()
    {
        

        return new ProfileDTO(Id, Name, Password, PasswordNew, ConfirmPassword, Email, Phone, NamePhoto);
    }
}
