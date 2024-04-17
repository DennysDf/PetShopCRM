using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Domain.Models;

public class Configuration : EntityBase
{
    public ConfigurationKey Key { get; set; }
    public string Value { get; set; }
    public ConfigurationType Type { get; set; }
    public ConfigurationGroup Group { get; set; }
}
