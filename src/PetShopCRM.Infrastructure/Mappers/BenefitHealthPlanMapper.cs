using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Infrastructure.Mappers;

public class BenefitHealthPlanMapper : IEntityTypeConfiguration<BenefitHealthPlan>
{
    public void Configure(EntityTypeBuilder<BenefitHealthPlan> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Benefit
        builder.Property(x => x.Coparticipation)
           .IsRequired();

        builder.Property(x => x.AnnualLimit)
           .IsRequired();

        builder.Property(x => x.Lack)
           .IsRequired();
       
        builder.Property(x => x.HealthPlanId)
            .IsRequired();

        builder.HasOne(x => x.HealthPlan)
            .WithMany(x => x.BenefitHealthPlans)
            .HasForeignKey(x => x.HealthPlanId)
            .HasConstraintName("BenefitsHealthPlan_HealthPlan_HealthPlanId");


        builder.HasOne(x => x.Benefit)
            .WithMany(x => x.BenefitHealthPlans)
            .HasForeignKey(x => x.BenefitId)
            .HasConstraintName("BenefitsHealthPlan_Benefit_BenefitId");

        //Filter
        builder.HasQueryFilter(x => x.Active);
    }
}
