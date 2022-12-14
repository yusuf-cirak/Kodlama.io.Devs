using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.AddProgrammingLanguage
{
    [AuthorizationPipeline(Roles = "User,Admin")]
    public class AddProgrammingLanguageCommandRequest:IRequest<AddProgrammingLanguageCommandResponse>, ISecuredRequest
    {
        public string Name { get; set; }
    }
    
    public sealed class AddProgrammingLanguageCommandHandler:IRequestHandler<AddProgrammingLanguageCommandRequest,AddProgrammingLanguageCommandResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        private readonly IMapper _mapper;

        public AddProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules,IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _mapper = mapper;
        }

        public async Task<AddProgrammingLanguageCommandResponse> Handle(AddProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCannotBeDuplicatedWhenInsertedOrBeforeUpdated(request.Name);

            ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);

            ProgrammingLanguage addedProgrammingLanguage =
               await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);

            AddProgrammingLanguageCommandResponse response =
                _mapper.Map<AddProgrammingLanguageCommandResponse>(addedProgrammingLanguage);


           return response;
        }
    }
    
    public sealed class AddProgrammingLanguageCommandResponse:AddedProgrammingLanguageDto
    {
    }
}
