using Microsoft.AspNetCore.SignalR;
using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Web.SignalHubs;

public class NotificationHub : Hub
{
    public async Task SendNotificationAll(NotificationType notificationType, string message)
    {
        await Clients.All.SendAsync("ReceiveNotificationAll", message);
    }

    public async Task SendNotificationUser(int userId, NotificationType notificationType, string message)
    {
        await Clients.Group(userId.ToString()).SendAsync("ReceiveNotificationUser", message);
    }


    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }
}
