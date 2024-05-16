using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Infrastructure.Mappers;

public class BenefitsMapper : IEntityTypeConfiguration<Benefit>
{
    public void Configure(EntityTypeBuilder<Benefit> builder)
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
        builder.Property(x => x.Procedure)
           .IsRequired();

        builder.Property(x => x.GroupId)
           .IsRequired();

        builder.HasOne(x => x.Group)
            .WithMany(x => x.Benefits)
            .HasForeignKey(x => x.GroupId)
            .HasConstraintName("Benefit_Group_GroupId");
    }
}