using System.ComponentModel;

namespace PetShopCRM.Domain.Enums;

public enum UserType
{
    [Description("Administrador")]
    Admin,
    [Description("Geral")]
    General,
    [Description("Tutor")]
    Guardian
}
