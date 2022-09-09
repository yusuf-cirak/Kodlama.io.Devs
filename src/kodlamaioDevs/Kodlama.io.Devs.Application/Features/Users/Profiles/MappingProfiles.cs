using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUser;

namespace Kodlama.io.Devs.Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterUserCommandRequest, User>();
        }
    }
}
