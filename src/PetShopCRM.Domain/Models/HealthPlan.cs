﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Domain.Models;

public class HealthPlan : EntityBase
{
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }

}
