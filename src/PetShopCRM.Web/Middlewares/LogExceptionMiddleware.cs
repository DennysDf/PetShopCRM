using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Middlewares;

public class LogExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext, ILogService logService, INotificationService notificationService)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logService.SaveAsync(LogType.Error, message: httpContext.Request.Path, exception: ex).GetAwaiter().GetResult();
            notificationService.Error("Houve um erro inesperado! Entre em contato com o suporte.");
            httpContext.Response.Redirect("/User/Login");
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
