﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class ProcedureGroupMapper : IEntityTypeConfiguration<ProcedureGroup>
{
    public void Configure(EntityTypeBuilder<ProcedureGroup> builder)
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
        builder.Property(x => x.Description)
               .IsRequired();
    }
}