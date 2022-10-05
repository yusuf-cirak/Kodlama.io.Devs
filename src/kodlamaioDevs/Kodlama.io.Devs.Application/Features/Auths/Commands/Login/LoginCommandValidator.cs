using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login
{
    public sealed class LoginCommandValidator:AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidator()
        {
            RuleFor(u=>u.Email).NotEmpty().EmailAddress().WithMessage("Please check your email format");

            RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Minimum password length is 6");
        }
    }
}
