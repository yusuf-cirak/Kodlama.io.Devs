using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetList
{
    public class GetOperationClaimListQueryRequest:IRequest<GetOperationClaimListQueryResponse>
    {
    }

    public class GetOperationClaimListQueryHandler : IRequestHandler<GetOperationClaimListQueryRequest, GetOperationClaimListQueryResponse>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetOperationClaimListQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetOperationClaimListQueryResponse> Handle(GetOperationClaimListQueryRequest request, CancellationToken cancellationToken)
        {
            IList<OperationClaim> operationClaims = await _operationClaimRepository.Query().AsNoTracking().ToListAsync(cancellationToken);

            return _mapper.Map<GetOperationClaimListQueryResponse>(operationClaims);
        }
    }

    public class GetOperationClaimListQueryResponse:OperationClaimListModel
    {
    }
}
