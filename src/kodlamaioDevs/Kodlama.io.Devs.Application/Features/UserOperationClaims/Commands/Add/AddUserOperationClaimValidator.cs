using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.Add
{
    public sealed class AddUserOperationClaimValidator:AbstractValidator<AddUserOperationClaimCommandRequest>
    {
        public AddUserOperationClaimValidator()
        {
            RuleFor(e => e.UserId).NotEmpty().NotEqual(0).WithMessage("{PropertyName} cannot be 0");
            RuleFor(e => e.OperationClaimId).NotEmpty().NotEqual(0).WithMessage("{PropertyName} cannot be 0");
        }
        
    }
}
