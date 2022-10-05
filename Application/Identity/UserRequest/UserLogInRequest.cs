using Application.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.DTOs;

public class UserLogInRequest : IRequest<LogInResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}