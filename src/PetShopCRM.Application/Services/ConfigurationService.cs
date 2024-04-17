using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Configuration;
using PetShopCRM.Application.Resources;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class ConfigurationService(IUnitOfWork unitOfWork) : IConfigurationService
{
    public List<ConfigurationDTO> GetAll()
    {
        var configuratoins = unitOfWork.ConfigurationRepository.GetBy()
            .Select(x => new ConfigurationDTO(x.Id, x.Key, x.Value, x.Type, x.Group))
            .ToList();

        return configuratoins;
    }

    public ConfigurationDTO? GetByKey(ConfigurationKey key)
    {
        var configuration = unitOfWork.ConfigurationRepository.GetBy(x => x.Key == key).FirstOrDefault();

        if(configuration != null)
            return new ConfigurationDTO(configuration.Id, configuration.Key, configuration.Value, configuration.Type, configuration.Group);

        return null;
    }

    public async Task<ResponseDTO<Configuration?>> AddOrUpdateAsync(ConfigurationKey key, string value)
    {
        var configuration = unitOfWork.ConfigurationRepository.GetBy(x => x.Key == key).FirstOrDefault();

        try
        {
            if (configuration != null)
            {
                configuration.Value = value ?? string.Empty;

                await unitOfWork.ConfigurationRepository.AddOrUpdateAsync(configuration);

                await unitOfWork.SaveChangesAsync();

                return new ResponseDTO<Configuration>(true, Message.ConfigurationSuccessUpdate, configuration);
            }
        }
        catch (Exception ex)
        {
            return new ResponseDTO<Configuration?>(false, ex.Message, null);
        }

        return new ResponseDTO<Configuration?>(false, Message.ConfigurationErrorUpdate, null);
    }
}
