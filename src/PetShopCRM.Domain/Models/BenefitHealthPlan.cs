using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Domain.Models;

public class BenefitHealthPlan : EntityBase
{
    public decimal Coparticipation { get; set; }
    public int AnnualLimit { get; set; }
    public int Lack { get; set; }
    public int HealthPlanId { get; set; }
    public HealthPlan HealthPlan { get; set; }
    public int BenefitId { get; set; }
    public Benefit Benefit { get; set; }
}