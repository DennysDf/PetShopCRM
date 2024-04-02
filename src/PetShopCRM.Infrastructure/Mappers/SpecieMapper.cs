using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class SpecieMapper : IEntityTypeConfiguration<Specie>
{
    public void Configure(EntityTypeBuilder<Specie> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Specie
        builder.Property(x => x.Name)
            .IsRequired();

        //Filter
        builder.HasQueryFilter(x => x.Active);
    }
}
