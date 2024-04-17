using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Application.DTOs.Configuration;

public record ConfigurationDTO(int Id, ConfigurationKey Key, string Value, ConfigurationType Type, ConfigurationGroup Group);