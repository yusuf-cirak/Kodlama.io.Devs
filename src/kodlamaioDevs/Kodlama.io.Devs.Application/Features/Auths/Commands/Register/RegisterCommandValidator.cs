using Core.Security.Dtos;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.RegisterUser
{
    public  sealed class RegisterCommandValidator:AbstractValidator<UserForRegisterDto>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Invalid e-mail format");

            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name cannot be empty");
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be longer than 6 characters");
        }
    }
}
