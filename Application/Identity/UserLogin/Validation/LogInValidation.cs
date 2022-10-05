using Application.DTOs;
using FluentValidation;

namespace Application.Identity.Validation;

public class LogInValidation : AbstractValidator<UserLogInRequest>
{
    public LogInValidation()
    {
        RuleFor(p => p.Username).NotNull().NotEmpty().WithMessage("Username is required");
        RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("Password is required");
    }
}