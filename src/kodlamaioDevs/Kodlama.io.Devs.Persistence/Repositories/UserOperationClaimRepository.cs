using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public sealed class UserOperationClaimRepository:EfRepositoryBase<UserOperationClaim,KodlamaioDevsContext>,IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(KodlamaioDevsContext context) : base(context)
        {
        }
    }
}
