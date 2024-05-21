using Microsoft.AspNetCore.SignalR;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Web.Services.Interfaces;
using PetShopCRM.Web.SignalHubs;
using PetShopCRM.Web.Util;

namespace PetShopCRM.Web.Services;

public class NotificationService(IHubContext<NotificationHub> hubContext) : INotificationService
{
    public void Send(NotificationType type, string message, int userId = 0)
    {
        if(userId == 0)
            hubContext.Clients.All.SendAsync("ReceiveNotificationAll", GenerateNotification(type, message)).GetAwaiter().GetResult();
        else
            hubContext.Clients.Group(userId.ToString()).SendAsync("ReceiveNotificationUser", GenerateNotification(type, message)).GetAwaiter().GetResult();
    }

    public void Error(string? message = null)
    {
        message ??= Resources.Text.NotificationError;

        NotificationUtil.Stack.Push(GenerateNotification(NotificationType.Error, message));
    }

    public void Success(string message)
    {
        NotificationUtil.Stack.Push(GenerateNotification(NotificationType.Information, message));
    }

    public void Warning(string message)
    {
        NotificationUtil.Stack.Push(GenerateNotification(null, message));
    }

    public static string GenerateNotification(NotificationType? type, string message)
    {
        return type switch
        {
            NotificationType.Error => $"alertify.error('{message}')",
            NotificationType.Information => $"alertify.success('{message}')",
            NotificationType.Warning => $"alertify.warning('{message}')",
            _ => $"alertify.notify('{message}', 'warning', 5);"
        };
    }
}
