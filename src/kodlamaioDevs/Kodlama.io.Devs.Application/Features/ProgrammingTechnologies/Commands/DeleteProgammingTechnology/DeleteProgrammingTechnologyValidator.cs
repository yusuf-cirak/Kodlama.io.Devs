using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgammingTechnology
{
    public class DeleteProgrammingTechnologyValidator:AbstractValidator<DeleteProgrammingTechnologyCommandRequest>
    {
        public DeleteProgrammingTechnologyValidator()
        {
            RuleFor(pt => pt.Id).NotEmpty().GreaterThan(0).WithMessage("ProgrammingTechnology id must be greater than zero");
        }
    }
}
