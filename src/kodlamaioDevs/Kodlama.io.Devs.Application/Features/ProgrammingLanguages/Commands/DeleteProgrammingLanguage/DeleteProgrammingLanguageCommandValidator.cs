using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator:AbstractValidator<DeleteProgrammingLanguageCommandRequest>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Id).NotEmpty();
        }
    }
}
