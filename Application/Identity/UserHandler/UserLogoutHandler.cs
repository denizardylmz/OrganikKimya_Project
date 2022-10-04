using Application.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity;

public class UserLogOutHandler : IRequestHandler<UserLogOutRequest, int>
{
    private readonly SignInManager<AppUser> _signInManager;


    public async Task<int> Handle(UserLogOutRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _signInManager.SignOutAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return 1;
    }
}