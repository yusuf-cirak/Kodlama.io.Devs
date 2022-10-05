using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Delete
{
    public sealed class DeleteOperationClaimCommandValidator:AbstractValidator<DeleteOperationClaimCommandRequest>
    {
        public DeleteOperationClaimCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty().NotEqual(0).WithMessage("{PropertyName} can not be equal to 0");
        }
    }
}
