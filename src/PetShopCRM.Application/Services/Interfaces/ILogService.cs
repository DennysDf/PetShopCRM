using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface ILogService
{
    Task<Log?> SaveAsync(LogType type, string? message = null, Exception? exception = null);
}
