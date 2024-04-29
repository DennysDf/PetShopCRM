using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Mappers;

public class PaymentHistoryMapper : IEntityTypeConfiguration<PaymentHistory>
{
    public void Configure(EntityTypeBuilder<PaymentHistory> builder)
    {
        //EnttityBase
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired(false);

        builder.Property(x => x.Active)
            .IsRequired();

        //PaymentHistory
        builder.Property(x => x.PaymentId)
           .IsRequired();

        builder.Property(x => x.IsSuccess)
            .IsRequired();

        builder.Property(x => x.Event)
            .IsRequired();

        builder.Property(x => x.Value)
           .IsRequired();

        builder.HasOne(x => x.Payment)
            .WithMany(x => x.PaymentHistories)
            .HasForeignKey(x => x.PaymentId)
            .HasConstraintName("PaymentHistories_Payments_PaymentId");

        //Filter
        builder.HasQueryFilter(x => x.Active);
    }
}
