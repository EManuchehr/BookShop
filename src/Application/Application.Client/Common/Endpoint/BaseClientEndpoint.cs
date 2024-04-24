using Application.Client.Common.Interfaces;
using Shared.Core.Endpoints;

namespace Application.Client.Common.Endpoint;

public abstract class BaseClientEndpoint<TResponse> : EndpointBase<TResponse>, IClientEndpoint
    where TResponse : class
{
}

public abstract class BaseClientEndpoint<TRequest, TResponse> : EndpointBase<TRequest, TResponse>, IClientEndpoint
    where TResponse : class
    where TRequest : class
{
}