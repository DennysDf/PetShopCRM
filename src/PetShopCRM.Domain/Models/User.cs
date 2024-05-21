using PetShopCRM.Domain.Enums;

namespace PetShopCRM.Domain.Models;

public class User : EntityBase
{
    public string Name { get; set; }
    public UserType Type { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CPF { get; set; }
    public string UrlPhoto { get; set; }
    public int? GuardianId { get; set; }
    public Guardian Guardian { get; set; }
}
