using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.UserOperationClaimService
{
    public sealed class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimManager(IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task RegisterUserWithClaim(User user, string userClaim)
        {
            await AddClaimsToUser(user, new[] {userClaim});
        }

        public async Task AddClaimsToUser(User user, string[] userClaims)
        {
            List<OperationClaim> operationClaims = await GetOperationClaims(userClaims);

            foreach (var operationClaim in operationClaims)
            {
                user.UserOperationClaims.Add(new(0, userId: user.Id, operationClaimId: operationClaim.Id));
            }
        }

        private async Task<List<OperationClaim>> GetOperationClaims(string[] userClaims)
        {
            var operationClaims = new List<OperationClaim>();

            foreach (string userClaim in userClaims)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(e => e.Name == userClaim);

                if (operationClaim == null) continue;

                operationClaims.Add(operationClaim);
            }

            return operationClaims;
        }
    }
}
