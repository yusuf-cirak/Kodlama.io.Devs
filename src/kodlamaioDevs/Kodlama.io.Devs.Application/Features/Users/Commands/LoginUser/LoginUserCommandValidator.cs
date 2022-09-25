using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser
{
    public sealed class LoginUserCommandValidator:AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u=>u.Email).NotEmpty().EmailAddress().WithMessage("Please check your email format");

            RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Minimum password length is 6");
        }
    }
}
