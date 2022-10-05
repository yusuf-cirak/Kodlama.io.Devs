using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Update
{
    public sealed class UpdateOperationClaimValidator:AbstractValidator<UpdateOperationClaimCommandRequest>
    {
        public UpdateOperationClaimValidator()
        {
            RuleFor(e => e.Id).NotEmpty().NotEqual(0).WithMessage("{PropertyName} can not be equal to 0");
            RuleFor(e => e.Name).NotEmpty().NotEqual("string").WithMessage("{PropertyName} can not be equal to string");
        }
    }
}
