using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

using IClientApplicationDbContext = Application.Client.Common.Interfaces.IApplicationDbContext;

public static class ServiceCollection
{
    public static IServiceCollection AddClientPersistenceInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ClientApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ClientApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IClientApplicationDbContext>(provider =>
            provider.GetRequiredService<ClientApplicationDbContext>());

        return services;
    }
}