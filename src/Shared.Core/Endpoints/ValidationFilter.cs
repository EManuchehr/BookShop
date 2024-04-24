using Shared.Core.Endpoints.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Core.Endpoints;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var argToValidate = context.Arguments.FirstOrDefault(x => x?.GetType() == typeof(T)) as T;
        
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator is not null)
        {
            var validationResult = await validator.ValidateAsync(argToValidate!);
            if (!validationResult.IsValid)
            {
                return Results.Ok(new ErrorResponse(ResponseErrorCode.BadRequest, null,
                    validationResult.ToDictionary()));
            }
        }
        
        return await next.Invoke(context);
    }
}