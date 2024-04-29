using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

using IClientApplicationDbContext = Application.Client.Common.Interfaces.IApplicationDbContext;
using IAdminApplicationDbContext = Application.Admin.Common.Interfaces.IApplicationDbContext;

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

    public static IServiceCollection AddAdminPersistenceInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AdminApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AdminApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IAdminApplicationDbContext>(provider =>
            provider.GetRequiredService<AdminApplicationDbContext>());

        return services;
    }

    public static IServiceCollection AddIdentityPersistenceInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<IdentityApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(IdentityApplicationDbContext).Assembly.FullName)));

        return services;
    }
}