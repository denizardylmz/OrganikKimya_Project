using Application.Common;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Identity;

public class LogInResponse : IResponse<AppUser>
{
    public string Message { get; set; }
    public ResponseType ResponseType { get; set; }
    public AppUser Data { get; set; }

}