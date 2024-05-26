using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Infrastructure.Mappers;

public class PaymentMapper : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Payment
        builder.Property(x => x.ExternalId)
            .IsRequired(false);

        builder.Property(x => x.PetId)
            .IsRequired();

        builder.Property(x => x.GuardianId)
            .IsRequired();

        builder.Property(x => x.HealthPlanId)
            .IsRequired();

        builder.Property(x => x.IsRecurrence)
            .IsRequired();

        builder.Property(x => x.Installment)
            .IsRequired();

        builder.Property(x => x.FirstPayment)
            .IsRequired(false);

        builder.Property(x => x.LastPayment)
            .IsRequired(false);

        builder.Property(x => x.IsSuccess)
            .IsRequired();

        builder.HasOne(x => x.Pet)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.PetId)
            .HasConstraintName("Payments_Pets_PetId");

        builder.HasOne(x => x.Guardian)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.GuardianId)
            .HasConstraintName("Payments_Guardians_GuardianId");

        builder.HasOne(x => x.HealthPlan)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.HealthPlanId)
            .HasConstraintName("Payments_HealthPlans_HealthPlanId");
    }
}
