using System.Diagnostics;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandRequest:IRequest<UpdateProgrammingLanguageCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UpdateProgrammingLanguageCommandHandler:IRequestHandler<UpdateProgrammingLanguageCommandRequest,UpdateProgrammingLanguageCommandResponse>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task<UpdateProgrammingLanguageCommandResponse> Handle(UpdateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
    {

        await _programmingLanguageBusinessRules.ProgrammingLanguageNameCannotBeDuplicatedBeforeUpdated(request.Name);

        ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
        ProgrammingLanguage updatedProgrammingLanguage = await 
            _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);

        UpdateProgrammingLanguageCommandResponse response =
            _mapper.Map<UpdateProgrammingLanguageCommandResponse>(updatedProgrammingLanguage);

        return response;
    }
}

public class UpdateProgrammingLanguageCommandResponse:UpdatedProgrammingLanguageDto
{
    
}