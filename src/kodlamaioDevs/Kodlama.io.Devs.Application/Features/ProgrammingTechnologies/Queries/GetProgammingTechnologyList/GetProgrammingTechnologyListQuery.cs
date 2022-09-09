using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetProgammingTechnologyList
{
    public class GetProgrammingTechnologyListQueryRequest:PageRequest,IRequest<GetProgrammingTechnologyListQueryResponse>
    {
    }

    public class GetProgrammingTechnologyListQueryHandler:IRequestHandler<GetProgrammingTechnologyListQueryRequest,GetProgrammingTechnologyListQueryResponse>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public GetProgrammingTechnologyListQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<GetProgrammingTechnologyListQueryResponse> Handle(GetProgrammingTechnologyListQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingTechnology> programmingTechnology =
                await _programmingTechnologyRepository.GetListAsync(
                    index: request.Page,
                    size: request.PageSize);

             _programmingTechnologyBusinessRules.ItemsCannotBeNullWhenRequested(programmingTechnology);


            return _mapper.Map<GetProgrammingTechnologyListQueryResponse>(programmingTechnology);
        }
    }

    public class GetProgrammingTechnologyListQueryResponse:ProgrammingTechnologyListModel
    {
    }
}
