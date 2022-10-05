using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.UserOperationClaimService
{
    public interface IUserOperationClaimService
    {
        Task RegisterUserWithClaim(User user, string userClaim);
        Task AddClaimsToUser(User user, string[] userClaims);
    }
}
