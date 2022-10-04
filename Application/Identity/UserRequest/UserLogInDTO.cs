using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.DTOs;

public class UserLogInDTO : IRequest<SignInResult>
{
    public string Username { get; set; }
    public string Password { get; set; }
}