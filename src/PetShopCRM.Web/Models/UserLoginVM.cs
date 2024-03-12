using PetShopCRM.Application.DTOs;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = ValidationKeys.Required)]
        [DisplayName("Usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = ValidationKeys.Required)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        public UserLoginDTO ToDTO()
        {
            return new UserLoginDTO(Login, Password);
        }
    }
}
