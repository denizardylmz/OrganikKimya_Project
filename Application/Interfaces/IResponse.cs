using Application.Common;

namespace Application.Interfaces;

public interface IResponse
{
    string Message { get; set; }
     
    ResponseType ResponseType { get; set; }
}