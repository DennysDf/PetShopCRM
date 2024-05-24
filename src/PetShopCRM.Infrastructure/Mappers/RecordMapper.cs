using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Infrastructure.Mappers;

public class RecordMapper : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Record
        builder.Property(x => x.Date)
        .IsRequired();

        builder.Property(x => x.PetId)
        .IsRequired();

        builder.Property(x => x.ProcedureHealthPlanId)
        .IsRequired();

        builder.Property(x => x.ReasonConsultation)
        .IsRequired(false);

        builder.Property(x => x.ClinicalHistory)
        .IsRequired(false);

        builder.Property(x => x.PhysicalExam)
        .IsRequired(false);

        builder.Property(x => x.Diagnosis)
        .IsRequired(false);

        builder.Property(x => x.Prescription)
        .IsRequired(false);

        builder.Property(x => x.Observation)
        .IsRequired(false);

        builder.HasOne(x => x.Pet)
        .WithMany(x => x.Records)
        .HasForeignKey(x => x.PetId)
        .HasConstraintName("Record_Pets_PetId");

        builder.HasOne(x => x.ProcedureHealthPlan)
        .WithMany(x => x.Records)
        .HasForeignKey(x => x.ProcedureHealthPlanId)
        .HasConstraintName("Record_ProceduresHealthPlans_ProcedureHealthPlanId");

    }
}
