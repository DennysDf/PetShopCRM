using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class LogService(IUnitOfWork unitOfWork) : ILogService
{
    public async Task<Log?> SaveAsync(LogType type, string? message = null, Exception? exception = null)
    {
        var log = new Log
        {
            Type = type,
            Message = message,
            Exception = exception?.Message ?? null,
            StackTrace =  string.Join("", exception?.StackTrace?.Take(8000) ?? "") ?? null,
            InnerException = exception?.InnerException?.Message ?? null,
            InnerStackTrace = string.Join("", exception?.InnerException?.StackTrace?.Take(8000) ?? "") ?? null,
        };

        await unitOfWork.LogRepository.AddOrUpdateAsync(log);
        await unitOfWork.SaveChangesAsync();

        return log;
    }
}
