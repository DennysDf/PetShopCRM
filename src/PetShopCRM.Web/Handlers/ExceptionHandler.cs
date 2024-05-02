using Microsoft.AspNetCore.Diagnostics;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Web.Handlers;

public class ExceptionHandler(ILogService logService) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logService.SaveAsync(LogType.Error, message: httpContext.Request.Path, exception: exception).GetAwaiter().GetResult();

        return ValueTask.FromResult(false);
    }
}
