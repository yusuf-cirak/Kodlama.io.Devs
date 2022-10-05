using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.Update
{
    [AuthorizationPipeline(Roles = "Admin")]

    public sealed class UpdateOperationClaimCommandRequest:IRequest<bool>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public sealed class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommandRequest, bool>
    {
        private readonly OperationClaimBusinessRules _businessRules;
        private readonly IMapper _mapper;
        private readonly IOperationClaimRepository _repository;

        public UpdateOperationClaimCommandHandler(OperationClaimBusinessRules businessRules, IMapper mapper, IOperationClaimRepository repository)
        {
            _businessRules = businessRules;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaim = await _businessRules.OperationClaimMustExistBeforeUpdatedOrDeleted(request.Id);

            operationClaim.Name = request.Name;

            await _repository.UpdateAsync(operationClaim);

            return true;

        }
    }
}
