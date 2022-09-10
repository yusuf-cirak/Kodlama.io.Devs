using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class GithubProfileRepository:EfRepositoryBase<GithubProfile,KodlamaioDevsContext>,IGithubProfileRepository
    {
        public GithubProfileRepository(KodlamaioDevsContext context) : base(context)
        {
        }
    }
}
