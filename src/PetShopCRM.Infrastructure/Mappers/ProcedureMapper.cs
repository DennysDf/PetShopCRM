using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Infrastructure.Mappers;

public class ProcedureMapper : IEntityTypeConfiguration<Procedure>
{
    public void Configure(EntityTypeBuilder<Procedure> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Procedure     
        builder.Property(x => x.Description)
           .IsRequired();

        builder.Property(x => x.ProcedureGroupId)
           .IsRequired();

        builder.HasOne(x => x.ProcedureGroup)
            .WithMany(x => x.Procedures)
            .HasForeignKey(x => x.ProcedureGroupId)
            .HasConstraintName("Procedures_ProcedureGroups_ProcedureGroupId");
    }
}