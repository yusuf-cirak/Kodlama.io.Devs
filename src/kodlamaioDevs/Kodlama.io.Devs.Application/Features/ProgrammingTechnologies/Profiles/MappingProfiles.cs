using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.AddProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetProgammingTechnologyList;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetProgrammingTechnologyListDynamic;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddProgrammingTechnologyCommandRequest,ProgrammingTechnology>();

            CreateMap<ProgrammingTechnology, AddProgrammingTechnologyCommandResponse>();


            CreateMap<UpdateProgrammingTechnologyCommandRequest,ProgrammingTechnology>();
            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommandResponse>();


            CreateMap<ProgrammingTechnology,DeleteProgrammingTechnologyCommandResponse>();


            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>();
            CreateMap<IPaginate<ProgrammingTechnology>, GetProgrammingTechnologyListQueryResponse>();

            CreateMap<IPaginate<ProgrammingTechnology>, GetProgrammingTechnologyListDynamicQueryResponse>();

        }
    }
}
