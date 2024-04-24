using System.Reflection;
using Application.Admin.Common.Interfaces;
using Asp.Versioning;
using Asp.Versioning.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Admin;

public static class EndpointServiceCollection
{
    public static void AddAdminEndpoints(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        AddEndpointsFromAssembly(Assembly.GetExecutingAssembly(), services);
    }

    public static void UseAdminEndpoints(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(1, 0)
            .Build();

        var mapGroup = app.MapGroup("api/admin/")
            .WithApiVersionSet(versionSet)
            .HasApiVersion(1, 0)
            .WithTags("Admin");

        var endpointServices = scope.ServiceProvider.GetServices<IAdminEndpoint>();

        foreach (var endpointService in endpointServices)
        {
            endpointService.AddRoute(mapGroup);
        }
    }

    private static void AddEndpointsFromAssembly(Assembly assembly, IServiceCollection services)
    {
        var clientEndpoints = assembly
            .GetTypes()
            .Where(x => x is { IsAbstract: false, IsInterface: false, BaseType: not null } &&
                        x.GetInterfaces().Contains(typeof(IAdminEndpoint)))
            .ToList();

        foreach (var clientEndpoint in clientEndpoints)
        {
            services.AddSingleton(typeof(IAdminEndpoint), clientEndpoint);
        }
    }
}