using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Services.Interfaces;

public interface ILoginService
{
    Task LoginAsync(User user);
    Task LogoutAsync();
}
