using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Web.Services.Interfaces;

public interface INotificationService
{
    void Send(NotificationType type, string message, int userId = 0);
    void Success(string message);
    void Warning(string message);
    void Error(string? message = null);
}
