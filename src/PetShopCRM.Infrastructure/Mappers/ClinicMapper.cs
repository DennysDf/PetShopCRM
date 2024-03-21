using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class ClinicMapper : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Clinic
        builder.Property(x => x.Name)
           .IsRequired();

        builder.Property(x => x.Address)
           .IsRequired(false);

        builder.Property(x => x.Phone)
           .IsRequired(false);

        builder.Property(x => x.Responsible)
           .IsRequired(false);

        builder.Property(x => x.CNPJ)
           .IsRequired();
    }
}
