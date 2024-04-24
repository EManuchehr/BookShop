using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        
        builder.Property(x => x.FirstName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasMany(x => x.ShippingAddresses)
            .WithOne(y => y.CreatedByUser)
            .HasForeignKey(z => z.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}