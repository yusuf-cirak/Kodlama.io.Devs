using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgammingTechnology
{
    public class DeleteProgrammingTechnologyCommandRequest:IRequest<DeleteProgrammingTechnologyCommandResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteProgrammingTechnologyCommandHandler:IRequestHandler<DeleteProgrammingTechnologyCommandRequest,DeleteProgrammingTechnologyCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

        public DeleteProgrammingTechnologyCommandHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
        {
            _mapper = mapper;
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
        }

        public async Task<DeleteProgrammingTechnologyCommandResponse> Handle(DeleteProgrammingTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingTechnology programmingTechnology =
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistBeforeDeleted(request.Id);

           await _programmingTechnologyRepository.DeleteAsync(programmingTechnology);

           DeleteProgrammingTechnologyCommandResponse response =
               _mapper.Map<DeleteProgrammingTechnologyCommandResponse>(programmingTechnology);

           return response;
        }
    }

    public class DeleteProgrammingTechnologyCommandResponse:DeletedProgrammingTechnologyDto
    {
    }
}
