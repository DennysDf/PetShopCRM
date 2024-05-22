using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class ProcedureHealthPlanMapper : IEntityTypeConfiguration<ProcedureHealthPlan>
{
    public void Configure(EntityTypeBuilder<ProcedureHealthPlan> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //ProcedureHealthPlan
        builder.Property(x => x.Coparticipation)
           .IsRequired();

        builder.Property(x => x.CoparticipationUnit)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.AnnualLimit)
           .IsRequired(false);

        builder.Property(x => x.Lack)
           .IsRequired();
       
        builder.Property(x => x.HealthPlanId)
            .IsRequired();

        builder.Property(x => x.ProcedureId)
            .IsRequired();

        builder.Property(x => x.Observation)
            .IsRequired(false);

        builder.HasOne(x => x.HealthPlan)
            .WithMany(x => x.ProcedureHealthPlans)
            .HasForeignKey(x => x.HealthPlanId)
            .HasConstraintName("ProcedureHealthPlans_HealthPlan_HealthPlanId");

        builder.HasOne(x => x.Procedure)
            .WithMany(x => x.ProcedureHealthPlans)
            .HasForeignKey(x => x.ProcedureId)
            .HasConstraintName("ProcedureHealthPlans_Procedures_ProcedureId");
    }
}
