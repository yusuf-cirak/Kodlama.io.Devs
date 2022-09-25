using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.AddGithubProfile
{
    public sealed class AddGithubProfileCommandValidator:AbstractValidator<AddGithubProfileCommandRequest>
    {
        public AddGithubProfileCommandValidator()
        {
            RuleFor(g => g.ProfileName).NotEmpty().WithMessage("You must enter a profile name");
        }
    }
}
