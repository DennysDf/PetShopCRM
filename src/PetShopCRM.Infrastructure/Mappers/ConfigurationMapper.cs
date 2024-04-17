using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class ConfigurationMapper : IEntityTypeConfiguration<Configuration>
{
    public void Configure(EntityTypeBuilder<Configuration> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //Configuration
        builder.Property(x => x.Key)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.Value)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.Group)
            .IsRequired()
            .HasConversion<int>();

        //Filter
        builder.HasQueryFilter(x => x.Active);
    }
}
