using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public class IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity");

        builder.Entity<IdentityUser<Guid>>().ToTable("Users").HasIndex(x => x.Id);
        builder.Entity<IdentityRole<Guid>>().ToTable("Roles").HasIndex(x => x.Id);
        builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasNoKey();
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims").HasIndex(x => x.Id);
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasNoKey();
        builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasNoKey();
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims").HasIndex(x => x.Id);
    }
}