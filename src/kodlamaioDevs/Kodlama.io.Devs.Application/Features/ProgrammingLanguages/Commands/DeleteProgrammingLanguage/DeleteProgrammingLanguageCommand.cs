using System;
using System.Collections.Generic;
using System.Data;
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

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    [AuthorizationPipeline(Roles = "User,Admin")]

    public sealed class DeleteProgrammingLanguageCommandRequest:IRequest<DeleteProgrammingLanguageCommandResponse>, ISecuredRequest
    {
        public int Id { get; set; }
    }

    public sealed class DeleteProgrammingLanguageCommandHandler:IRequestHandler<DeleteProgrammingLanguageCommandRequest,DeleteProgrammingLanguageCommandResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        private readonly IMapper _mapper;

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _mapper = mapper;
        }


        public async Task<DeleteProgrammingLanguageCommandResponse> Handle(DeleteProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistBeforeDeleted(request.Id);

            await _programmingLanguageRepository.DeleteAsync(programmingLanguage);

            DeleteProgrammingLanguageCommandResponse response=_mapper.Map<DeleteProgrammingLanguageCommandResponse>(programmingLanguage);
            return response;

        }
    }

    public sealed class DeleteProgrammingLanguageCommandResponse:DeletedProgrammingLanguageDto
    {
    }
}
