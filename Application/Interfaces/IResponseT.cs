using Application.Common;

namespace Application.Interfaces;

public interface IResponse<T> : IResponse
{
    public T Data { get; set; }
    

}