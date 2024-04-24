using Application.Client.Common.Endpoint;
using Application.Client.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Application.Client.Features.Locations.CreateLocation;

public class CreateLocation : BaseClientEndpoint<CreateLocationRequest, CreateLocationResponse>
{
    public override void AddRoute(IEndpointRouteBuilder app)
    {
        Post(app, "locations", HandleAsync);
    }

    private async Task<IResult> HandleAsync([FromBody] CreateLocationRequest request,
        [FromServices] IApplicationDbContext dbContext,
        [FromServices] IMapper mapper)
    {
        var location = mapper.Map<Location>(request);

        await dbContext.Locations.AddAsync(location);
        await dbContext.SaveChangesAsync();

        return SuccessResponse(mapper.Map<CreateLocationResponse>(location));
    }
}