using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Create
{
    [AuthorizationPipeline(Roles = "Admin")]
    public sealed class CreateOperationClaimCommandRequest : IRequest<bool>,ISecuredRequest
    {
        public string Name { get; set; }
    }

    public sealed class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommandRequest, bool>
    {
        private readonly IOperationClaimRepository
             _operationClaimRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<bool> Handle(CreateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
           await _operationClaimBusinessRules.ClaimNameCannotBeDuplicatedWhenInserted(request.Name);

            var operationClaim = _mapper.Map<OperationClaim>(request);

            await _operationClaimRepository.AddAsync(operationClaim);

            return true;
        }
    }
}
