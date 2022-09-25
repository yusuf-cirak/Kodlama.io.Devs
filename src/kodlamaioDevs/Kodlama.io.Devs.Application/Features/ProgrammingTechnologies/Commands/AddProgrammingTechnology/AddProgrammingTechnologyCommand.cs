using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.AddProgrammingTechnology
{
    [AuthorizationPipeline(Roles ="User,Admin")]
    public sealed class AddProgrammingTechnologyCommandRequest : IRequest<AddProgrammingTechnologyCommandResponse>,ISecuredRequest
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

    }
    public sealed class AddProgrammingTechnologyCommandHandler : IRequestHandler<AddProgrammingTechnologyCommandRequest, AddProgrammingTechnologyCommandResponse>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public AddProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<AddProgrammingTechnologyCommandResponse> Handle(AddProgrammingTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            await _programmingTechnologyBusinessRules.ProgrammingTechnologyCannotDuplicatedBeforeInsertedOrUpdated(
                request.Name);
            await _programmingTechnologyBusinessRules.ProgrammingLangaugeShouldExistBeforeTechnologyAdded(request.ProgrammingLanguageId);

            ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);

            ProgrammingTechnology addedProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);

            AddProgrammingTechnologyCommandResponse response =
                _mapper.Map<AddProgrammingTechnologyCommandResponse>(addedProgrammingTechnology);

            return response;
        }
    }
    public sealed class AddProgrammingTechnologyCommandResponse : AddedProgrammingTechnologyDto
    {
    }
}
