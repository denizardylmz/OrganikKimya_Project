using Application.Common;
using Application.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity;

public class UserLoginHandler : IRequestHandler<UserLogInRequest, LogInResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public UserLoginHandler(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<LogInResponse> Handle(UserLogInRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);

        if (user != null)
        {
            await _signInManager.SignOutAsync();
            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (signInResult.Succeeded)
            {
                return new LogInResponse()
                {
                    Data = user,
                    Message = signInResult.ToString(),
                    ResponseType = ResponseType.Success
                };    
            }
            else
            {
                return new LogInResponse()
                {
                    Data = null,
                    Message = signInResult.ToString(),
                    ResponseType = ResponseType.NotFound
                };
            }
            
        }
        return new LogInResponse()
        {
            Data = null,
            Message = "User not found",
        };
    }
}