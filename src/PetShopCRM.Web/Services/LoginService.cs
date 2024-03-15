using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Services.Interfaces;
using System.Security.Claims;

namespace PetShopCRM.Web.Services;

public class LoginService(IHttpContextAccessor httpContextAccessor) : ILoginService
{
    public async Task LoginAsync(User user)
    {
        var claims = new List<Claim>()
        {
            new("Id", user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, user.Type.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
            AllowRefresh = true
        };

        if (httpContextAccessor.HttpContext is not null)
            await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
    }

    public async Task LogoutAsync()
    {
        if (httpContextAccessor.HttpContext is not null)
            await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
