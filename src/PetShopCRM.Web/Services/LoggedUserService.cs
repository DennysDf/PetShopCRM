using PetShopCRM.Web.Services.Interfaces;
using System.Security.Claims;

namespace PetShopCRM.Web.Services;

public class LoggedUserService(IHttpContextAccessor httpContextAccessor) : ILoggedUserService
{
    public int Id => GetId();

    public string Name => httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ?? "";

    public string Role => httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Role) ?? "";

    public string Image => httpContextAccessor?.HttpContext?.User?.FindFirstValue("Image") ?? "";

    private int GetId()
    {
        bool success = int.TryParse(httpContextAccessor?.HttpContext?.User?.FindFirstValue("Id") ?? "0", out int id);

        return success ? id : 0;
    }
}
