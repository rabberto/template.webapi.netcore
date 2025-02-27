namespace Template.Webapi.Netcore.Domain.Commands.Shared;

public sealed class BaseCommandResponse
{
    public BaseCommandResponse(Guid correlationId, int statusCode, object data)
    {
        CorrelationId = correlationId;
        StatusCode = statusCode;
        Data = data;
        Success = true;
        Errors = [];
    }

    public BaseCommandResponse(Guid correlationId, int statusCode)
    {
        CorrelationId = correlationId;
        StatusCode = statusCode;
        Success = true;
        Errors = [];
    }
    
    public BaseCommandResponse(Guid correlationId, int statusCode, string errors)
    {
        CorrelationId = correlationId;
        StatusCode = statusCode;
        Success = false;
        Errors = [errors];
    }

    public BaseCommandResponse(Guid correlationId, int statusCode, bool success, string errors)
    {
        CorrelationId = correlationId;
        StatusCode = statusCode;
        Success = success;
        Errors = [errors];
    }

    public Guid CorrelationId { get; private set; }
    public bool Success { get; private set; }
    public object? Data { get; private set; }
    public int StatusCode { get; private set; }
    public IEnumerable<string> Errors { get; private set; }
}