using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Contexts;

public class ClientApplicationDbContextFactory : IDesignTimeDbContextFactory<ClientApplicationDbContext>
{
    public ClientApplicationDbContext CreateDbContext(string[] args)
    {
        var environmentName =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environmentName}.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ClientApplicationDbContext>();

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        return new ClientApplicationDbContext(optionsBuilder.Options);
    }
}