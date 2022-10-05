using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetList
{
    public sealed class GetUserOperationClaimsListQueryRequest:IRequest<GetUserOperationClaimsListQueryResponse>
    {
        public int UserId { get; set; }
    }

    public sealed class GetUserOperationClaimsListQueryHandler : IRequestHandler<GetUserOperationClaimsListQueryRequest, GetUserOperationClaimsListQueryResponse>
    {
        private readonly UserOperationClaimBusinessRules _businessRules;

        public GetUserOperationClaimsListQueryHandler(UserOperationClaimBusinessRules businessRules)
        {
            _businessRules = businessRules;
        }

        public async Task<GetUserOperationClaimsListQueryResponse> Handle(GetUserOperationClaimsListQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _businessRules.UserAndOperationClaimsMustExistBeforeListed(request.UserId);

            var userOperationClaimsDtoList = user.UserOperationClaims.Select(e => new UserOperationClaimDto
            {
                Id=e.Id,
                OperationClaimId=e.OperationClaimId,
                OperationClaimName=e.OperationClaim.Name
            }).ToArray();


            var response = new GetUserOperationClaimsListQueryResponse
            {
                UserId = user.Id,
                UserName = $"{user.FirstName} {user.LastName}",
                UserOperationClaimsDtoList = userOperationClaimsDtoList
            };

            return response;
        }
    }

    public sealed class GetUserOperationClaimsListQueryResponse:GetUserOperationClaimsListModel
    {
    }
}
