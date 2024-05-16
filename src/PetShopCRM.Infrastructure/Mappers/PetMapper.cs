using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class PetMapper : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Pet
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.GuardianId)
            .IsRequired();

        builder.Property(x => x.Identifier)
            .IsRequired(false);

        builder.Property(x => x.SpecieId)
            .IsRequired();

        builder.Property(x => x.Sexy)
            .IsRequired(false);

        builder.Property(x => x.Color)
            .IsRequired(false);

        builder.Property(x => x.Weight)
            .IsRequired(false);

        builder.Property(x => x.Age)
            .IsRequired(false);

        builder.Property(x => x.Breed)
            .IsRequired(false);

        builder.Property(x => x.Obs)
            .IsRequired(false);

        builder.Property(x => x.Spayed)
            .IsRequired(false);

        builder.Property(x => x.UrlPhoto)
            .IsRequired(false);

        builder.HasOne(x => x.Guardian)
            .WithMany(x => x.Pets)
            .HasForeignKey(x => x.GuardianId)
            .HasConstraintName("Pets_Guardians_GuardianId");

        builder.HasOne(x => x.Specie)
            .WithMany(x => x.Pets)
            .HasForeignKey(x => x.SpecieId)
            .HasConstraintName("Pets_Species_SpecieId");

        //Filter
        builder.HasQueryFilter(x => x.Active);
    }
}
