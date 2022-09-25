using System;
using System.Collections;
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
    public sealed class RegisterUserCommandRequest:UserForRegisterDto,IRequest<RegisterUserCommandResponse>
    {
    }

    public sealed class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommandRequest,RegisterUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EmailCannotBeDuplicatedBeforeRegistered(request.Email);

            HashingHelper.CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
           User user = _mapper.Map<User>(request);
           user.PasswordSalt = passwordSalt;
           user.PasswordHash = passwordHash;
           //user.Status = true;


           List<OperationClaim> operationClaims = new List<OperationClaim>();

           operationClaims.Add(new OperationClaim(2,"User"));



           var userOperationClaims = new List<UserOperationClaim>();


           User createdUser = await _userRepository.AddAsync(user);

           userOperationClaims.Add(new(0, user.Id, operationClaims[0].Id));


           await _userOperationClaimRepository.AddRangeAsync(userOperationClaims);



           AccessToken token=_tokenHelper.CreateToken(createdUser,operationClaims);

           return new() { AccessToken = token };

        }
    }

    public sealed class RegisterUserCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}
