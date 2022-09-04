using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.AddProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageList;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {

        // AddProgrammingLanguageCommand maps
        CreateMap<AddProgrammingLanguageCommandRequest, ProgrammingLanguage>();

        CreateMap<ProgrammingLanguage, AddProgrammingLanguageCommandResponse>();

        // DeleteProgrammingLanguageCommand maps

        CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommandResponse>();

        // UpdateProgrammingLanguageCommand maps

        CreateMap<UpdateProgrammingLanguageCommandRequest, ProgrammingLanguage>();

        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommandResponse>();

        // GetProgrammingLanguageByIdQuery maps
        CreateMap<ProgrammingLanguage, GetProgrammingLanguageByIdQueryResponse>();

        // GetProgrammingLanguageListQuery maps
        CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>();
        CreateMap<IPaginate<ProgrammingLanguage>, GetProgrammingLanguageListQueryResponse>();


    }

}