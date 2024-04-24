using Microsoft.AspNetCore.Routing;

namespace Shared.Core.Endpoints;

public interface IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app);
}