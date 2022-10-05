using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Rules
{
    public sealed class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        internal async Task ClaimNameCannotBeDuplicatedWhenInserted(string name)
        {
            if (await _operationClaimRepository.GetAsync(e => e.Name == name) != null)
                throw new BusinessException("Operation claim exists");
        }

        internal async Task<OperationClaim> OperationClaimMustExistBeforeUpdatedOrDeleted(int id)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(e => e.Id == id);

            if (operationClaim == null) throw new BusinessException("Operation claim does not exist");

            return operationClaim;
        }
    }
}
