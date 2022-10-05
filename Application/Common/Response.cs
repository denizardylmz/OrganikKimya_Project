using Application.Interfaces;

namespace Application.Common;

public class Response : IResponse
{
    public string Message { get; set; }
    public ResponseType ResponseType { get; set; }

    public Response(ResponseType responseType)
    {
        ResponseType = responseType;
    }

    public Response(ResponseType responseType, string responseMessage) : this(responseType)
    {
        Message = responseMessage;
    }

}

public enum ResponseType {
    Success,
    ValidationError,
    NotFound
}