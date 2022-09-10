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

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommandRequest:IRequest<UpdateGithubProfileCommandResponse>,ISecuredRequest
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }

        public string[] Roles { get; } = { "User" };
    }

    public class UpdateGithubProfileCommandHandler:IRequestHandler<UpdateGithubProfileCommandRequest,UpdateGithubProfileCommandResponse>
    {
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly IMapper _mapper;
        private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

        public UpdateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
        {
            _githubProfileRepository = githubProfileRepository;
            _mapper = mapper;
            _githubProfileBusinessRules = githubProfileBusinessRules;
        }

        public async Task<UpdateGithubProfileCommandResponse> Handle(UpdateGithubProfileCommandRequest request, CancellationToken cancellationToken)
        { 
            
           GithubProfile profile= await _githubProfileBusinessRules.CheckDbForGithubProfileBeforeUpdated(request.Id);

           _githubProfileBusinessRules.UserMustVerifiedBeforeProfileDeletedOrUpdated(profile.UserId);

           ReceivedGithubProfileDto profileDto =
               await _githubProfileBusinessRules.GithubProfileShouldExistBeforeAdded(request.ProfileName);

           var mappedProfile = _mapper.Map<GithubProfile>(profileDto);
           mappedProfile.Id=profile.Id;
           mappedProfile.UserId = profile.UserId;

           GithubProfile updatedProfile = await _githubProfileRepository.UpdateAsync(mappedProfile);

           return _mapper.Map<UpdateGithubProfileCommandResponse>(updatedProfile);

        }
    }

    public class UpdateGithubProfileCommandResponse:UpdatedGithubProfileDto
    {
    }
}
