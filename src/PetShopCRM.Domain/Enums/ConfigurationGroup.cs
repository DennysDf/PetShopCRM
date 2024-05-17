﻿using System.ComponentModel;

namespace PetShopCRM.Domain.Enums;

public enum ConfigurationGroup
{
    [Description("Sistema")]
    System = 0,
    [Description("Integração Pagar.me")]
    PagarMe = 1,
    [Description("Envio de E-mail")]
    Email = 2
}
