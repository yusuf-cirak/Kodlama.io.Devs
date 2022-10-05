using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Delete
{
    public sealed class DeleteOperationClaimCommandRequest:IRequest<bool>
    {
        public int Id { get; set; }
    }

    public sealed class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommandRequest, bool>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly OperationClaimBusinessRules _businessRules;

        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules businessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _businessRules = businessRules;
        }

        public async Task<bool> Handle(DeleteOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaim = await _businessRules.OperationClaimMustExistBeforeUpdatedOrDeleted(request.Id);

            await _operationClaimRepository.DeleteAsync(operationClaim);

            return true;
        }
    }

}
