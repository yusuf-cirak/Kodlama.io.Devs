using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task ProgrammingLanguageNameCannotBeDuplicatedWhenInsertedOrBeforeUpdated(string name)
    {
        // IPaginate<ProgrammingLanguage> programmingLanguages =
        //     await _programmingLanguageRepository.GetListAsync(pl => pl.Name==name);

        ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Name == name);

        if (programmingLanguage is not null)
            throw new BusinessException("ProgrammingLanguage already exists with that name");
    }

    public async Task ProgrammingLanguageNameCannotBeDuplicatedBeforeUpdated(string name)
    {
        ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Name == name);

        if (programmingLanguage is not null)
            throw new BusinessException("ProgrammingLanguage already exists with that name");
    }

    public async Task<ProgrammingLanguage> ProgrammingLanguageShouldExistBeforeDeleted(int id)
    {
        ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == id);
        if (programmingLanguage==null)
        {
            throw new BusinessException("ProgrammingLanguage does not exist");
        }

        return programmingLanguage;
    }

    public async Task<ProgrammingLanguage> ProgrammingLanguageShouldExistWhenRequested(int id)
    {
        ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == id);
        if (programmingLanguage == null)
        {
            throw new BusinessException("ProgrammingLanguage does not exist");
        }

        return programmingLanguage;
    }
}