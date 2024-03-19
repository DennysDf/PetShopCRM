using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models.Usuario;

public class ProfileVM
{
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Senha")]
    public string Password { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [Compare(nameof(Password),ErrorMessage = ValidationKeysUtil.ComparePassword)]
    [DisplayName("Confirmar senha")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [EmailAddress(ErrorMessage = ValidationKeysUtil.Email)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Telefone")]
    public string Phone { get; set; }

    

    public void ToViewModel(User model)
    {
        Name = model.Name;
        Password = model.Password;
        Email = model.Email;
    }
}
