using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Auths.Commands.RegisterUser;

namespace Kodlama.io.Devs.Application.Features.Auths.Profiles
{
    public sealed class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
