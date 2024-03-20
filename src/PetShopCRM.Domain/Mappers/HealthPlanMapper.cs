using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Domain.Mappers;

public class HealthPlanMapper : IEntityTypeConfiguration<HealthPlan>
{
    public void Configure(EntityTypeBuilder<HealthPlan> builder)
    {

    }
}
