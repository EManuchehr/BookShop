using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(x => x.Address)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Latitude)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.Longitude)
            .HasMaxLength(15)
            .IsRequired();

        builder.HasOne(x => x.City)
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}