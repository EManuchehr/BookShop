using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CopyrightConfiguration : IEntityTypeConfiguration<Copyright>
{
    public void Configure(EntityTypeBuilder<Copyright> builder)
    {
        builder.Property(x => x.BookId)
            .IsRequired();

        builder.HasIndex(x => x.BookId)
            .IsUnique();
    }
}