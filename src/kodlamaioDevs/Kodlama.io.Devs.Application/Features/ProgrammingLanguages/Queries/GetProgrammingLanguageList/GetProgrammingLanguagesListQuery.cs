using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageList
{
    public class GetProgrammingLanguageListQueryRequest:PageRequest,IRequest<GetProgrammingLanguageListQueryResponse>
    {
    }

    public class GetProgrammingLanguageListQueryHandler:IRequestHandler<GetProgrammingLanguageListQueryRequest,GetProgrammingLanguageListQueryResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetProgrammingLanguageListQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetProgrammingLanguageListQueryResponse> Handle(GetProgrammingLanguageListQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguages = await 
                _programmingLanguageRepository.GetListAsync(index:request.Page,size:request.PageSize);

            GetProgrammingLanguageListQueryResponse response =
                _mapper.Map<GetProgrammingLanguageListQueryResponse>(programmingLanguages);
            return response;


        }
    }

    public class GetProgrammingLanguageListQueryResponse:ProgrammingLanguageListModel
    {
    }
}
