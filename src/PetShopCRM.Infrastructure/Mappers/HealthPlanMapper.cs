using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class HealthPlanMapper : IEntityTypeConfiguration<HealthPlan>
{
    public void Configure(EntityTypeBuilder<HealthPlan> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //HealthPlan
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Value)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired(false);

        //Filter
        builder.HasQueryFilter(x => x.Active);
    }
}
