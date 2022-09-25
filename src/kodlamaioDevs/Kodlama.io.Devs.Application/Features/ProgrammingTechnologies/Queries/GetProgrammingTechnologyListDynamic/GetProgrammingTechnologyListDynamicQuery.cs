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

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetProgrammingTechnologyListDynamic
{
    public sealed class GetProgrammingTechnologyListDynamicQueryRequest:IRequest<GetProgrammingTechnologyListDynamicQueryResponse>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }

    public sealed class GetProgrammingTechnologyListDynamicQueryHandler:IRequestHandler<GetProgrammingTechnologyListDynamicQueryRequest,GetProgrammingTechnologyListDynamicQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public GetProgrammingTechnologyListDynamicQueryHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _mapper = mapper;
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<GetProgrammingTechnologyListDynamicQueryResponse> Handle(GetProgrammingTechnologyListDynamicQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingTechnology> programmingTechnology =
                await _programmingTechnologyRepository.GetListByDynamicAsync(dynamic: request.Dynamic,
                    include: pt => pt.Include(pt => pt.ProgrammingLanguage), index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

            _programmingTechnologyBusinessRules.ItemsOrLanguagesCannotBeNullWhenRequested(programmingTechnology);

            return _mapper.Map<GetProgrammingTechnologyListDynamicQueryResponse>(programmingTechnology);
        }
    }

    public sealed class GetProgrammingTechnologyListDynamicQueryResponse:ProgrammingTechnologyListModel
    {
    }
}
