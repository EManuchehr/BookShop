using Application.Client.Common.Endpoint;
using Application.Client.Common.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Endpoints.Responses;

namespace Application.Client.Features.Publishers.GetPublisher;

public class GetPublisher : BaseClientEndpoint<GetPublisherResponse>
{
    public override void AddRoute(IEndpointRouteBuilder app)
    {
        Get(app, "publishers/{publisherId}", HandleAsync);
    }

    private async Task<IResult> HandleAsync([FromRoute] Guid publisherId,
        [FromServices] IApplicationDbContext dbContext,
        [FromServices] IMapper mapper)
    {
        var publisher = await dbContext.Publishers
            .Include(p => p.Location)
            .ThenInclude(x => x!.Country)
            .Include(p => p.Location)
            .ThenInclude(x => x!.City)
            .FirstOrDefaultAsync(p => p.Id == publisherId);

        if (publisher == null)
            return ErrorResponse(ResponseErrorCode.NotFound, "Publisher not found");

        return SuccessResponse(mapper.Map<GetPublisherResponse>(publisher));
    }
}