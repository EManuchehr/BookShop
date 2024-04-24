namespace Shared.Core.Endpoints.Responses;

public class ErrorResponse : ResponseBase<string>
{
    public ErrorResponse(ResponseErrorCode errorCode, string? message = null,
        IDictionary<string, string[]>? errors = null) : base(false, errorCode, null!, null!, message, errors)
    {
    }
}