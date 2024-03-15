using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Web.Models;

public class ResponseVM<T>
{
    public bool Success { get; set; }
    public bool HasNotification => Notification != null;
    public NotificationResponseVM? Notification { get; set; }
    public bool HasRedirect => Redirect != null;
    public RedirectResponseVM? Redirect { get; set; }
    public bool HasValidation => Validations != null && Validations.Count != 0;
    public List<ValidationFormResponseVM>? Validations { get; set; }
    public T? Data { get; set; }
}

public record NotificationResponseVM(
    string Type,
    string Message
    );

public record RedirectResponseVM(
    string Action,
    string Controller,
    Dictionary<string, string>? Parameters = null
    );

public record ValidationFormResponseVM(
    string Field,
    string Message
    );