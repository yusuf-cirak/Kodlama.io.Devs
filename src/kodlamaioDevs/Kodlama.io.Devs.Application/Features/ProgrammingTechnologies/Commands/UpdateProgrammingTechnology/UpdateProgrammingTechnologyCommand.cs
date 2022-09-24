using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    [AuthorizationPipeline(Roles = "User,Admin")]

    public class UpdateProgrammingTechnologyCommandRequest:IRequest<UpdateProgrammingTechnologyCommandResponse>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateProgrammingTechnologyCommandHandler:IRequestHandler<UpdateProgrammingTechnologyCommandRequest,UpdateProgrammingTechnologyCommandResponse>
    {
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;
        private readonly IMapper _mapper;
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public UpdateProgrammingTechnologyCommandHandler(ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules, IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            _mapper = mapper;
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task<UpdateProgrammingTechnologyCommandResponse> Handle(UpdateProgrammingTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingTechnology? programmingTechnology =
                await _programmingTechnologyRepository.Query().AsNoTracking()
                    .FirstOrDefaultAsync(pt => pt.Id == request.Id);

            await _programmingTechnologyBusinessRules.ProgrammingTechnologyCannotDuplicatedBeforeInsertedOrUpdated(
                request.Name);

            await _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistBeforeUpdated(programmingTechnology);

            programmingTechnology = _mapper.Map<ProgrammingTechnology>(request);

            ProgrammingTechnology updatedProgrammingTechnology =
                await _programmingTechnologyRepository.UpdateAsync(programmingTechnology);

            UpdateProgrammingTechnologyCommandResponse response =
                _mapper.Map<UpdateProgrammingTechnologyCommandResponse>(updatedProgrammingTechnology);
            return response;
        }
    }

    public class UpdateProgrammingTechnologyCommandResponse:UpdatedProgrammingTechnologyDto
    {
    }
}
