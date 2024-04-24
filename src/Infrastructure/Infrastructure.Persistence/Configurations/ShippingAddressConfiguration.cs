using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ShippingAddressConfiguration : IEntityTypeConfiguration<ShippingAddress>
{
    public void Configure(EntityTypeBuilder<ShippingAddress> builder)
    {
        builder.Property(x => x.PostalCode)
            .HasMaxLength(15);

        builder.HasOne(x => x.Location)
            .WithMany()
            .HasForeignKey(y => y.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}