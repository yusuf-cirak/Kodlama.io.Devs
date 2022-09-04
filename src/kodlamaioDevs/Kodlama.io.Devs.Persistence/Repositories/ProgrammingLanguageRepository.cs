using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

public class ProgrammingLanguageRepository:EfRepositoryBase<ProgrammingLanguage,KodlamaioDevsContext>,IProgrammingLanguageRepository
{
    public ProgrammingLanguageRepository(KodlamaioDevsContext context) : base(context)
    {
    }
}