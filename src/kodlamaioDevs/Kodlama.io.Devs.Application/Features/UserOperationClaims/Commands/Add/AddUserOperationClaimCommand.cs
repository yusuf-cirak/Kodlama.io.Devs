using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.Add
{
    public sealed class AddUserOperationClaimCommandRequest : IRequest<bool>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }

    public sealed class AddUserOperationClaimCommandHandler : IRequestHandler<AddUserOperationClaimCommandRequest, bool>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _businessRules;
        private readonly IMapper _mapper;

        public AddUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules businessRules, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _businessRules = businessRules;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddUserOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            await _businessRules.UserAndOperationClaimMustExistBeforeAdded(request.UserId,request.OperationClaimId);
            // Operation claim must exist, User must exist before UserOperationClaim added

            await _businessRules.UserOperationClaimCannotBeDuplicatedBeforeAdded(request.UserId,request.OperationClaimId);
            // UserOperationClaim cannot exist before added



            await _userOperationClaimRepository.AddAsync(_mapper.Map<UserOperationClaim>(request));

            return true;
        }
    }

}
