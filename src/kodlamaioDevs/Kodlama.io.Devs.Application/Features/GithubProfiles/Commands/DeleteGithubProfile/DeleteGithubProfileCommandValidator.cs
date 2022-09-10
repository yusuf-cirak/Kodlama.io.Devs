using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommandValidator:AbstractValidator<DeleteGithubProfileCommandRequest>
    {
        public DeleteGithubProfileCommandValidator()
        {
            RuleFor(g => g.Id).NotEmpty().GreaterThan(0);
        }
    }
}
