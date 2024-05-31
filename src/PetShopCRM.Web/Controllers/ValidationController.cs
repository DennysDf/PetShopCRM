using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers
{
    public class ValidationController(
        ILoggedUserService loggedUserService,
        IUserService userService,
        IGuardianService guardianService) : Controller
    {
        [AcceptVerbs("GET", "POST")]
        public async Task<bool> PasswordEqualsCurrent(string password)
        {
            var userDTO = await userService.GetUserByIdAsync(loggedUserService.Id);

            return userDTO.Data.Password == password;
        }

        [AcceptVerbs("GET", "POST")]
        public bool UserCpfExists(string cpf, int id)
        {
            var userDTO = userService.GetUserByCPForEmail(cpf.FormatCpf());

            if ((id == 0 && userDTO?.Data != null) ||
                (id != 0 && (userDTO?.Data != null && userDTO.Data.Id != id)))
                return false;

            return true;
        }

        [AcceptVerbs("GET", "POST")]
        public bool GuardianCpfExists(string cpf, int id)
        {
            var userDTO = guardianService.GetByCPForEmail(cpf.FormatCpf());

            if ((id == 0 && userDTO?.Data != null) ||
                (id != 0 && (userDTO?.Data != null && userDTO.Data.Id != id)))
                return false;

            return true;
        }
    }
}
