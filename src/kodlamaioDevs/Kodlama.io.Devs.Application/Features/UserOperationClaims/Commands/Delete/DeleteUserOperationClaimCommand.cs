using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.Delete
{
    public sealed class DeleteUserOperationClaimCommandRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public sealed class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommandRequest, bool>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _businessRules;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules businessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _businessRules = businessRules;
        }

        public async Task<bool> Handle(DeleteUserOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var userOperationClaim = await _businessRules.UserAndOperationClaimMustExistBeforeDeleted(request.Id);

            await _userOperationClaimRepository.DeleteAsync(userOperationClaim);

            return true;
        }
    }
}
