using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules
{
    public sealed class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository, IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task ProgrammingLangaugeShouldExistBeforeTechnologyAdded(int id)
        {
            ProgrammingLanguage? programmingLanguage= await _programmingLanguageRepository.GetAsync(pl => pl.Id == id);

            if (programmingLanguage==null)
            {
                throw new BusinessException("Programming Technology cannot be added because Programming Language does not exist");
            }

        }

        public async Task ProgrammingTechnologyShouldExistBeforeUpdated(ProgrammingTechnology? programmingTechnology)
        {
            if (programmingTechnology==null)
            {
                throw new BusinessException("You can not update because ProgrammingTechnology does not exist");
            }
        }

        public async Task ProgrammingTechnologyCannotDuplicatedBeforeInsertedOrUpdated(string name)
        {
           ProgrammingTechnology? programmingTechnology= await _programmingTechnologyRepository.GetAsync(pl => pl.Name == name);
           if (programmingTechnology!=null)
           {
               throw new BusinessException("Technology name already exists");
           }
        }

        public async Task<ProgrammingTechnology> ProgrammingTechnologyShouldExistBeforeDeleted(int id)
        {
            ProgrammingTechnology? programmingTechnology =
                await _programmingTechnologyRepository.GetAsync(pt => pt.Id == id);
            if (programmingTechnology==null)
            {
                throw new BusinessException("You can not delete because ProgrammingTechnology does not exist");
            }

            return programmingTechnology;
        }

        public void ItemsCannotBeNullWhenRequested(IPaginate<ProgrammingTechnology> programmingTechnology)
        {
            if (programmingTechnology.Items == null)
            {
                throw new Exception("Something went wrong. Can not fetch the list");
            }
        }

        public void ItemsOrLanguagesCannotBeNullWhenRequested(IPaginate<ProgrammingTechnology>? programmingTechnology)
        {
            if (programmingTechnology?.Items == null)
            {
                throw new BusinessException("Something went wrong. Can not fetch the items");
            }

            if (!programmingTechnology.Items.Select(pt=>pt.ProgrammingLanguage).Any())
            {
                throw new BusinessException("Something went wrong. Can not fetch the languages");
            }
        }
    }
}
