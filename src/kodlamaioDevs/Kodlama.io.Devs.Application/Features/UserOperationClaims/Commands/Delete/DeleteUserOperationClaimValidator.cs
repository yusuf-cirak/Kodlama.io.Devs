using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.Delete
{
    public sealed class DeleteUserOperationClaimValidator:AbstractValidator<DeleteUserOperationClaimCommandRequest>
    {
        public DeleteUserOperationClaimValidator()
        {
            RuleFor(e => e.Id).NotEmpty().NotEqual(0).WithMessage("{PropertyName} cannot be equal to 0");
        }
    }
}
