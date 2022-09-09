using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Invalid e-mail format");

            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name cannot be empty");
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be longer than 6 characters");
        }
    }
}
