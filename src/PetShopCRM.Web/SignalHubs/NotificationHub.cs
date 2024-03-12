using Microsoft.AspNetCore.SignalR;
using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Web.SignalHubs;

public class NotificationHub : Hub
{
    public async Task SendNotification(int userId, NotificationType notificationType, string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", userId, notificationType, message);
    }
}
