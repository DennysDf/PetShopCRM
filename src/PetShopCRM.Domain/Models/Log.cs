using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Domain.Models;

public class Log : EntityBase
{
    public LogType Type { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }
    public string StackTrace { get; set; }
    public string InnerException { get; set; }
    public string InnerStackTrace { get; set; }
}
