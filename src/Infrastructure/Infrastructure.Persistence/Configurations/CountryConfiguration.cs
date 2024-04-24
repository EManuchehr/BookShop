using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasData(new Country
        {
            Id = new Guid("2757E51B-80F6-4AEB-86DA-9369CCD9B8A1"),
            Name = "Tajikistan",
            Code = "TJ",
            IsActive = true
        });
    }
}