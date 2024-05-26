namespace PetShopCRM.Application.Services.Interfaces;

public interface IWebContext
{
    public string GetScheme();
    public string GetHost();
    public string GeSystemUrl();
    public string GenerateUrl(string controller, string action, string? area = null);
}
