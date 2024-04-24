using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(20);

        builder.Property(x => x.LastName)
            .HasMaxLength(20);

        builder.Property(x => x.MiddleName)
            .HasMaxLength(20);

        builder.Property(x => x.Biography);

        builder.Property(x => x.ProfilePictureUrl)
            .HasMaxLength(255);

        builder.Property(x => x.DateOfBirth);

        builder.Property(x => x.DateOfDeath);

        builder.Property(x => x.OriginCountryId)
            .IsRequired();

        builder.HasOne(x => x.OriginCountry);
        
        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasMany(x => x.Books)
            .WithMany(x => x.BookAuthors);
    }
}