namespace PetShopCRM.Infrastructure.Settings;

public class AppSettings
{
    public AppSettingsPagarMe PagarMe { get; set; }
}

public class AppSettingsPagarMe
{
    public string User { get; set; }
    public string Password { get; set; }
}
