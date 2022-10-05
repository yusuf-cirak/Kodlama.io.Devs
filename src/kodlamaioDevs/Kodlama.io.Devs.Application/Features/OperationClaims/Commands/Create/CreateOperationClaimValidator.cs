using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Create
{
    public sealed class CreateOperationClaimValidator:AbstractValidator<CreateOperationClaimCommandRequest>
    {
        public CreateOperationClaimValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotEqual("string").WithMessage("{PropertyName} can not be equal to string");
        }
    }
}
