using PetShopCRM.Application.DTOs.User;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models.User;

public class UserLoginVM
{
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Usuário")]
    public string Login { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Senha")]
    public string Password { get; set; }

    public UserLoginDTO ToDTO()
    {
        return new UserLoginDTO(Login, Password);
    }
}
