using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public sealed class RefreshTokenRepository : EfRepositoryBase<RefreshToken, KodlamaioDevsContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(KodlamaioDevsContext context) : base(context)
        {
        }
    }
}
