using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Web.Services;

public class WebContext(IHttpContextAccessor httpContextAccessor) : IWebContext
{
    public string GetHost() => httpContextAccessor.HttpContext?.Request?.Host.Value ?? "";

    public string GetScheme() => httpContextAccessor.HttpContext?.Request?.Scheme ?? "";

    public string GeSystemUrl() => GetSystemUri().AbsoluteUri;

    public string GenerateUrl(string controller, string action, string? area = null) => 
        GenerateUri(controller, action, area).AbsoluteUri;

    private Uri GetSystemUri() => new($"{GetScheme()}://{GetHost()}");

    private Uri GenerateUri(string controller, string action, string? area = null) => 
        new(GetSystemUri(), $"{(area is null ? "" : $"{area}/")}{controller}/{action}");
}
