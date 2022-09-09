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
    public class ProgrammingTechnologyRepository:EfRepositoryBase<ProgrammingTechnology, KodlamaioDevsContext>,IProgrammingTechnologyRepository
    {
        public ProgrammingTechnologyRepository(KodlamaioDevsContext context) : base(context)
        {
        }
    }
}
