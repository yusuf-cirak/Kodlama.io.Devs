using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Core.Security.Extensions;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.AddGithubProfile
{
    public class AddGithubProfileCommandRequest:IRequest<AddGithubProfileCommandResponse>,ISecuredRequest
    {
        public string ProfileName { get; set; }
        public string[] Roles { get; } = { "Admin", "User" };
    }

    public class AddGithubProfileCommandHandler:IRequestHandler<AddGithubProfileCommandRequest,AddGithubProfileCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly GithubProfileBusinessRules _githubProfileBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddGithubProfileCommandHandler(GithubProfileBusinessRules githubProfileBusinessRules, IHttpContextAccessor httpContextAccessor, IMapper mapper, IGithubProfileRepository githubProfileRepository)
        {
            _githubProfileBusinessRules = githubProfileBusinessRules;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _githubProfileRepository = githubProfileRepository;
        }

        public async Task<AddGithubProfileCommandResponse> Handle(AddGithubProfileCommandRequest request, CancellationToken cancellationToken)
        {
            ReceivedGithubProfileDto profileDto = 
                await _githubProfileBusinessRules.GithubProfileShouldExistBeforeAdded(request.ProfileName);

            GithubProfile mappedProfile = _mapper.Map<GithubProfile>(profileDto);
            mappedProfile.UserId= _httpContextAccessor.HttpContext.User.GetUserId();

            GithubProfile addedProfile = await _githubProfileRepository.AddAsync(mappedProfile);


            var response = _mapper.Map<AddGithubProfileCommandResponse>(addedProfile);

            return response;

        }
    }

    public class AddGithubProfileCommandResponse:AddedGithubProfileDto
    {
    }
}
