using Application.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity;

public class UserLoginHandler : IRequestHandler<UserLogInDTO, SignInResult>
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

    public async Task<SignInResult> Handle(UserLogInDTO request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);

        if (user != null)
        {
            await _signInManager.SignOutAsync();
            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            return signInResult;
        }
        return SignInResult.Failed;
    }
}