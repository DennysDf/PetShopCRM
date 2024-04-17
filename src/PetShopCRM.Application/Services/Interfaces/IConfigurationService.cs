using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Configuration;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IConfigurationService
{
    List<ConfigurationDTO> GetAll();
    ConfigurationDTO? GetByKey(ConfigurationKey key);
    Task<ResponseDTO<Configuration?>> AddOrUpdateAsync(ConfigurationKey key, string value);
}