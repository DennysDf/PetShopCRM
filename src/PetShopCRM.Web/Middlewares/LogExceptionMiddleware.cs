using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Web.Middlewares;

public class LogExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext, ILogService logService)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logService.SaveAsync(LogType.Error, message: httpContext.Request.Path, exception: ex).GetAwaiter().GetResult();
        }
    }
}

public static class LogExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseLogException(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogExceptionMiddleware>();
    }
}
