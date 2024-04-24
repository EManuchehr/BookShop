using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CountryId)
            .IsRequired();

        builder.HasOne(x => x.Country)
            .WithMany(y => y.Cities)
            .HasForeignKey(x => x.CountryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasData(new City
            {
                Id = new Guid("30395D79-364F-4443-9EF7-A6F2B0DBF48F"),
                Name = "Dushanbe",
                Code = "DUS",
                CountryId = new Guid("2757E51B-80F6-4AEB-86DA-9369CCD9B8A1"),
                IsActive = true
            },
            new City
            {
                Id = new Guid("4BDC5646-122F-425D-81B4-5A0E365366E8"),
                Name = "Khujand",
                Code = "KHU",
                CountryId = new Guid("2757E51B-80F6-4AEB-86DA-9369CCD9B8A1"),
                IsActive = true
            });
    }
}