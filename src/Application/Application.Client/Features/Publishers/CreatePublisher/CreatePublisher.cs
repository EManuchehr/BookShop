using Application.Client.Common.Endpoint;
using Application.Client.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Application.Client.Features.Publishers.CreatePublisher;

public class CreatePublisher : BaseClientEndpoint<CreatePublisherResponse>
{
    public override void AddRoute(IEndpointRouteBuilder app)
    {
        Post(app, "publishers", HandleAsync);
    }

    private async Task<IResult> HandleAsync([FromBody] CreatePublisherRequest request,
        [FromServices] IApplicationDbContext dbContext,
        [FromServices] IMapper mapper)
    {
        var publisher = mapper.Map<Publisher>(request);

        dbContext.Publishers.Add(publisher);
        await dbContext.SaveChangesAsync();

        return SuccessResponse(mapper.Map<CreatePublisherResponse>(publisher));
    }
}