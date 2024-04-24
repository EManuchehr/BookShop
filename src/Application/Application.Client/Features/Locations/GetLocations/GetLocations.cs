using Application.Client.Common.Endpoint;
using Application.Client.Common.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Application.Client.Features.Locations.GetLocations;

public class GetLocations : BaseClientEndpoint<IList<GetLocationsResponse>>
{
    public override void AddRoute(IEndpointRouteBuilder app)
    {
        Get(app, "/locations", HandleAsync);
    }

    private async Task<IResult> HandleAsync([FromServices] IApplicationDbContext dbContext,
        [FromServices] IMapper mapper)
    {
        var locations = await dbContext.Locations.AsNoTracking().ToListAsync();

        var response = mapper.Map<IList<GetLocationsResponse>>(locations);

        return SuccessResponse(response);
    }
}