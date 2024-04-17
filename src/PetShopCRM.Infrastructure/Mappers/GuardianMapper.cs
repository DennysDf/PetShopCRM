using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Domain.Mappers;

public class GuardianMapper : IEntityTypeConfiguration<Guardian>
{
    public void Configure(EntityTypeBuilder<Guardian> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Guardian
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.DateBirth)
            .IsRequired(false);

        builder.Property(x => x.CPF)
            .IsRequired(false);

        builder.Property(x => x.Phone)
            .IsRequired(false);

        builder.Property(x => x.Email)
            .IsRequired(false);

        builder.Property(x => x.Address)
            .IsRequired(false);

        builder.Property(x => x.Country)
            .IsRequired(false);

        builder.Property(x => x.State)
            .IsRequired(false);

        builder.Property(x => x.City)
            .IsRequired(false);

        builder.Property(x => x.CEP)
            .IsRequired(false);

        builder.Property(x => x.Neighborhood)
          .IsRequired(false);
    }
}
