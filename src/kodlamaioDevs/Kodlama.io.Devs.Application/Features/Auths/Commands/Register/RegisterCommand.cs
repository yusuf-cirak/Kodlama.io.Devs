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
using Kodlama.io.Devs.Application.Features.Auths.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Application.Services.UserOperationClaimService;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.RegisterUser
{
    public sealed class RegisterCommandRequest:IRequest<RegisterCommandResponse>
    {
        public string IpAddress { get; }
        public UserForRegisterDto UserForRegisterDto { get; }
        public RegisterCommandRequest(UserForRegisterDto userForRegisterDto,string ipAddress)
        {
            UserForRegisterDto = userForRegisterDto;
            IpAddress = ipAddress;
        }
    }

    public sealed class RegisterUserCommandHandler:IRequestHandler<RegisterCommandRequest,RegisterCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _userBusinessRules;
        private readonly IAuthService _authService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository, AuthBusinessRules userBusinessRules, IAuthService authService, IUserOperationClaimService userOperationClaimService, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _authService = authService;
            _userOperationClaimService = userOperationClaimService;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.EmailCannotBeDuplicatedBeforeRegistered(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out byte[] passwordHash,out byte[] passwordSalt);

           var user = _mapper.Map<User>(request.UserForRegisterDto);
           user.PasswordSalt = passwordSalt;
           user.PasswordHash = passwordHash;

            await _userRepository.AddAsync(user);

            await _userOperationClaimService.RegisterUserWithClaim(user, userClaim: "User");

            await _userOperationClaimRepository.AddRangeAsync(user.UserOperationClaims.ToArray());


            var token = await _authService.CreateAccessToken(user);

            var refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);

            var addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

           return new() { AccessToken = token,RefreshToken= addedRefreshToken };

        }
    }

    public sealed class RegisterCommandResponse:RegisteredDto
    {
    }
}
