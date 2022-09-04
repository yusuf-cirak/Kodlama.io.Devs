using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById
{
    public class GetProgrammingLanguageByIdQueryRequest:IRequest<GetProgrammingLanguageByIdQueryResponse>
    {
        public int Id { get; set; }
    }

    public class GetProgrammingLanguageByIdQueryHandler:IRequestHandler<GetProgrammingLanguageByIdQueryRequest,GetProgrammingLanguageByIdQueryResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetProgrammingLanguageByIdQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<GetProgrammingLanguageByIdQueryResponse> Handle(GetProgrammingLanguageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(request.Id);

            GetProgrammingLanguageByIdQueryResponse response =
                _mapper.Map<GetProgrammingLanguageByIdQueryResponse>(programmingLanguage);

            return response;
        }
    }

    public class GetProgrammingLanguageByIdQueryResponse:GetProgrammingLanguageByIdDto
    {
    }
}
