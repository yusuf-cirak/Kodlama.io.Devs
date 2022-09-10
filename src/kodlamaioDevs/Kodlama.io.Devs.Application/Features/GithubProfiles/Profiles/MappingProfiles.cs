using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.AddGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ReceivedGithubProfileDto, GithubProfile>();

            CreateMap<GithubProfile, AddGithubProfileCommandResponse>();

            CreateMap<GithubProfile, DeleteGithubProfileCommandResponse>();

            CreateMap<GithubProfile, UpdateGithubProfileCommandResponse>();


        }
    }
}
