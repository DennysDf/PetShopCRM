namespace PetShopCRM.Infrastructure.Settings;

public class AppSettings
{
    public AppSettingsSmtp Smtp { get; set; }
}

public class AppSettingsSmtp
{
    public string Host { get; set; }
    public int Port { get; set; }
}
