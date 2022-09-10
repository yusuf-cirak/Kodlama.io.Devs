using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommandRequest:IRequest<DeleteGithubProfileCommandResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } = { "User" };
    }

    public class DeleteGithubProfileCommandHandler:IRequestHandler<DeleteGithubProfileCommandRequest,DeleteGithubProfileCommandResponse>
    {
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly GithubProfileBusinessRules _githubProfileBusinessRules;
        private readonly IMapper _mapper;

        public DeleteGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, GithubProfileBusinessRules githubProfileBusinessRules, IMapper mapper)
        {
            _githubProfileRepository = githubProfileRepository;
            _githubProfileBusinessRules = githubProfileBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeleteGithubProfileCommandResponse> Handle(DeleteGithubProfileCommandRequest request, CancellationToken cancellationToken)
        {
            
           GithubProfile profile=await _githubProfileBusinessRules.GithubProfileShouldExistBeforeDeletedOrUpdated(request.Id);

           _githubProfileBusinessRules.UserMustVerifiedBeforeProfileDeletedOrUpdated(profile.UserId);

           await _githubProfileRepository.DeleteAsync(profile);

           return _mapper.Map<DeleteGithubProfileCommandResponse>(profile);
        }
    }

    public class DeleteGithubProfileCommandResponse:DeletedGithubProfileDto
    {
    }
}
