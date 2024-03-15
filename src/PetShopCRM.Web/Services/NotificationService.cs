using Microsoft.AspNetCore.SignalR;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Web.Services.Interfaces;
using PetShopCRM.Web.SignalHubs;
using PetShopCRM.Web.Util;

namespace PetShopCRM.Web.Services;

public class NotificationService(IHubContext<NotificationHub> hubContext) : INotificationService
{
    public void Send(NotificationType type, string message)
    {
        hubContext.Clients.All.SendAsync("ReceiveNotification", type.ToString(), message).GetAwaiter().GetResult();
    }

    public void Error(string? message = null)
    {
        if (message == null) message = Resources.Text.NotificationError;

        NotificationUtil.Stack.Push($"alertify.error('{message}');");
    }

    public void Success(string message)
    {
        NotificationUtil.Stack.Push($"alertify.success('{message}');");
    }

    public void Warning(string message)
    {
        NotificationUtil.Stack.Push($"alertify.warning('{message}');");
    }
}
