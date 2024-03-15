using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Domain.Models;

public class User : EntityBase
{
    public string Name { get; set; }
    public UserType Type { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
