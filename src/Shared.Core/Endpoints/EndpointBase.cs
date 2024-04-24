using System.Diagnostics.CodeAnalysis;
using Shared.Core.Endpoints.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace Shared.Core.Endpoints;

public abstract class EndpointBase<TRequest, TResponse> : EndpointBase<TResponse>
    where TResponse : class where TRequest : class
{
    protected new RouteHandlerBuilder Post(IEndpointRouteBuilder app, [StringSyntax("Route")] string pattern,
        Delegate handler)
    {
        return base.Post(app, pattern, handler).AddEndpointFilter<ValidationFilter<TRequest>>();
    }

    protected new RouteHandlerBuilder Get(IEndpointRouteBuilder app, [StringSyntax("Route")] string pattern,
        Delegate handler)
    {
        return base.Get(app, pattern, handler).AddEndpointFilter<ValidationFilter<TRequest>>();
    }
}

public abstract class EndpointBase<TResponse> : IEndpoint where TResponse : class
{
    public abstract void AddRoute(IEndpointRouteBuilder app);

    protected static Ok<SuccessResponse<TResponse>> SuccessResponse(TResponse? data, Meta? meta = null,
        string? message = null)
    {
        return TypedResults.Ok(new SuccessResponse<TResponse>(data, meta, message));
    }

    protected static Ok<ErrorResponse> ErrorResponse(ResponseErrorCode responseErrorCode, string? message = null,
        IDictionary<string, string[]>? errors = null)
    {
        return TypedResults.Ok(new ErrorResponse(responseErrorCode, message, errors));
    }

    protected RouteHandlerBuilder Post(IEndpointRouteBuilder app, [StringSyntax("Route")] string pattern,
        Delegate handler)
    {
        return app.MapPost(pattern, handler)
            .Produces<SuccessResponse<TResponse>>()
            .Produces<ErrorResponse>();
    }

    protected RouteHandlerBuilder Get(IEndpointRouteBuilder app, [StringSyntax("Route")] string pattern,
        Delegate handler)
    {
        return app.MapGet(pattern, handler)
            .Produces<SuccessResponse<TResponse>>()
            .Produces<ErrorResponse>();
    }
}