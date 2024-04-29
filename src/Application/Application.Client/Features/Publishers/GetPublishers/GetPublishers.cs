using Application.Client.Common.Endpoint;
using Application.Client.Common.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Application.Client.Features.Publishers.GetPublishers;

public class GetPublishers : BaseClientEndpoint<IList<GetPublishersResponse>>
{
    public override void AddRoute(IEndpointRouteBuilder app)
    {
        Get(app, "publishers", HandleAsync);
    }

    private async Task<IResult> HandleAsync([FromServices] IApplicationDbContext dbContext,
        [FromServices] IMapper mapper)
    {
        var publishers = await dbContext.Publishers
            .Include(p => p.Location)
            .ThenInclude(x => x!.Country)
            .Include(p => p.Location)
            .ThenInclude(x => x!.City)
            .ToListAsync();

        return SuccessResponse(mapper.Map<IList<GetPublishersResponse>>(publishers));
    }
}