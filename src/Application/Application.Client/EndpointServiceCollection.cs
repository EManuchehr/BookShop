using Asp.Versioning;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Asp.Versioning.Conventions;
using Microsoft.AspNetCore.Builder;
using Application.Client.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client
{
    public static class EndpointServiceCollection
    {
        public static void AddClientEndpoints(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            AddEndpointsFromAssembly(Assembly.GetExecutingAssembly(), services);
        }

        public static void UseClientEndpoints(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var versionSet = app.NewApiVersionSet()
                .HasApiVersion(1, 0)
                .Build();

            var mapGroup = app.MapGroup("api/client/v{version:apiVersion}")
                .WithApiVersionSet(versionSet)
                .HasApiVersion(1, 0)
                .WithTags("Client");

            var endpointServices = scope.ServiceProvider.GetServices<IClientEndpoint>();

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
                            x.GetInterfaces().Contains(typeof(IClientEndpoint)))
                .ToList();

            foreach (var clientEndpoint in clientEndpoints)
            {
                services.AddSingleton(typeof(IClientEndpoint), clientEndpoint);
            }
        }
    }
}