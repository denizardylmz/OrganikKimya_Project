using Application.Interfaces;

namespace Application.Common;

public class Response<T> : Response, IResponse<T>
{
    public T Data { get; set; }
    
    
    public Response(ResponseType responseType, T data) : base(responseType)
    {
        Data = data;

    }

    public Response(string message, ResponseType responseType) : base(responseType, message)
    {
        
    }
}