using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Domain.Models;

public  class Benefit : EntityBase
{   
    public string Procedure { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public virtual ICollection<BenefitHealthPlan> BenefitHealthPlans { get; set; }

}
