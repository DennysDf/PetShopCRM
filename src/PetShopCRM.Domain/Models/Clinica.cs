using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Domain.Models
{
    public class Clinica : EntityBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Responsavel { get; set; }
        public string CNPJ { get; set; }

    }
}
