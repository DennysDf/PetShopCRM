using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Infrastructure.Data.Repository;
public class ProcedureRespository(PetShopDbContext context) : RepositoryBase<Benefit>(context), IProcedureRepository
{
}