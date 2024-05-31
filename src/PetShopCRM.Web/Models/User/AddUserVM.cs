using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models.User;
public class AddUserVM
{
    public int Id { get; set; }
    public bool IsCreate => Id == 0;

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Login")]
    public string Login { get; set; }

    [DisplayName("Senha")]
    [MinLength(6, ErrorMessage = ValidationKeysUtil.SizeMin)]
    [RequiredIf(nameof(IsCreate), ErrorMessage = ValidationKeysUtil.Required)]
    public string? Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = ValidationKeysUtil.ComparePassword)]
    [DisplayName("Confirmar Senha")]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Tipo de usuário")]
    public UserType? Type { get; set; }

    public SelectList TyUserList { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Telefone")]
    public string Phone { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [Remote("UserCpfExists", "Validation", AdditionalFields = "Id", ErrorMessage = ValidationKeysUtil.ValidateCPF)]
    [DisplayName("CPF")]
    public string CPF { get; set; }

    public static List<AddUserVM> ToList(List<Domain.Models.User> listUsers) => listUsers.Select(users => new AddUserVM {
        CPF = users.CPF,
        Name = users.Name,
        Type = users.Type,
        Email = users.Email,
        Phone = users.Phone,
        Id = users.Id,
        Login = users.Login,
        Password = users.Password        
    }).ToList();

    public Domain.Models.User ToModel() => new Domain.Models.User() { Id = this.Id, Name = this.Name, CPF = this.CPF, Email = this.Email, Login = this.Login, Password = this.Password, Phone = this.Phone };

    public AddUserVM ToVM(Domain.Models.User model) => new() { Id = model.Id, Login = model.Login, Password = model.Password, Name = model.Name, Type = model.Type, Email = model.Email, Phone = model.Phone, CPF = model.CPF };
}
