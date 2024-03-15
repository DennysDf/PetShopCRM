
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Domain.Models
{
    public class Pet : EntityBase
    {
        public string Nome { get; set; }
        public int TutorId { get; set; }
        public string Identificador { get; set; }
        public int EspecieId { get; set; }

    }
}
