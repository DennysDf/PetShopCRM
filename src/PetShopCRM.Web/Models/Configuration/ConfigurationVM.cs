using PetShopCRM.Application.DTOs.Configuration;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Web.Resources;

namespace PetShopCRM.Web.Models.Configuration;

public class ConfigurationVM
{
    public int Id { get; set; }
    public ConfigurationKey Key { get; set; }
    public string KeyDescription { get; set; }
    public string Value { get; set; }
    public ConfigurationType Type { get; set; }
    public ConfigurationGroup Group { get; set; }
    public string GroupDescription { get; set; }

    public static ConfigurationVM DtoToVM(ConfigurationDTO configurationDTO) => new ConfigurationVM
    {
        Id = configurationDTO.Id,
        Key = configurationDTO.Key,
        KeyDescription = ConfigurationKeyDescription.ResourceManager.GetString(configurationDTO.Key.ToString()) ?? "",
        Value = configurationDTO.Value,
        Type = configurationDTO.Type,
        Group = configurationDTO.Group,
        GroupDescription = EnumUtil.GetDescription(configurationDTO.Group)
    };

    public static List<ConfigurationVM> ListDtoToListVM(List<ConfigurationDTO> configurationsDTO) => configurationsDTO.Select(x => new ConfigurationVM
    {
        Id = x.Id,
        Key = x.Key,
        KeyDescription = ConfigurationKeyDescription.ResourceManager.GetString(x.Key.ToString()) ?? "",
        Value = x.Value,
        Type = x.Type,
        Group = x.Group,
        GroupDescription = EnumUtil.GetDescription(x.Group)
    }).ToList();
}
