using Application.Admin.Common.Interfaces;
using Shared.Core.Endpoints;

namespace Application.Admin.Common.Endpoint;

public abstract class BaseAdminEndpoint<TResponse> : EndpointBase<TResponse>, IAdminEndpoint
    where TResponse : class;

public abstract class BaseAdminEndpoint<TRequest, TResponse> : EndpointBase<TRequest, TResponse>, IAdminEndpoint
    where TResponse : class
    where TRequest : class;