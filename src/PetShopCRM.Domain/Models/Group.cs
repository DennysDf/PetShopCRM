using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Domain.Models
{
    public class Group : EntityBase
    {
        public string Description { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
    }
}
