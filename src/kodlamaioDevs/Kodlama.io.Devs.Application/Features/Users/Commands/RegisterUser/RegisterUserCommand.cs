using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Users.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandRequest:UserForRegisterDto,IRequest<RegisterUserCommandResponse>
    {
    }

    public class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommandRequest,RegisterUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly UserBusinessRules _userBusinessRules;

        public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EmailCannotBeDuplicatedBeforeRegistered(request.Email);

            HashingHelper.CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
           User user = _mapper.Map<User>(request);
           user.PasswordSalt = passwordSalt;
           user.PasswordHash = passwordHash;
           user.Status = true;


           User createdUser = await _userRepository.AddAsync(user);

           AccessToken token=_tokenHelper.CreateToken(createdUser, new List<OperationClaim>());

           return new() { AccessToken = token };

        }
    }

    public class RegisterUserCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}
