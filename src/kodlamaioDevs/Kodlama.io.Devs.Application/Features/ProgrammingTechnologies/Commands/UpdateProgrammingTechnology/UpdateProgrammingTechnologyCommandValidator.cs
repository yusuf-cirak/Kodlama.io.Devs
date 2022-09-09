using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandValidator:AbstractValidator<UpdateProgrammingTechnologyCommandRequest>
    {
        public UpdateProgrammingTechnologyCommandValidator()
        {
            RuleFor(pt => pt.Id).NotEmpty().GreaterThan(0).WithMessage("Id must be greater than zero");

            RuleFor(pt => pt.Name).NotEmpty().WithMessage("Name can not be empty");
        }
    }
}
