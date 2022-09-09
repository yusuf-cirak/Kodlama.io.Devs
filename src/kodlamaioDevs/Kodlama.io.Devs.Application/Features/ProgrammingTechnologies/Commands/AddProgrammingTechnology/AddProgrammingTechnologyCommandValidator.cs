using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.AddProgrammingTechnology
{
    public class AddProgrammingTechnologyCommandValidator:AbstractValidator<AddProgrammingTechnologyCommandRequest>
    {
        public AddProgrammingTechnologyCommandValidator()
        {
            RuleFor(pl => pl.ProgrammingLanguageId).NotEmpty().GreaterThan(0)
                .WithMessage("ProgrammingLanguageId cannot be 0");

            RuleFor(pl => pl.Name).NotEmpty().WithMessage("ProgrammingTechnology cannot be empty");
        }

    }
}
