using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Title)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Isbn)
            .HasMaxLength(13)
            .IsRequired();

        builder.Property(x => x.PublishedDate)
            .IsRequired();

        builder.HasMany(x => x.BookAuthors)
            .WithMany(y => y.Books);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}