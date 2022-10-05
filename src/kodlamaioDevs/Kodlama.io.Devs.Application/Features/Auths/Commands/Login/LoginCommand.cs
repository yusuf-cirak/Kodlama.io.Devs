using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Auths.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login
{
    public sealed class LoginCommandRequest:UserForLoginDto,IRequest<LoginCommandResponse>
    {
    }

    public sealed class LoginCommandHandler:IRequestHandler<LoginCommandRequest,LoginCommandResponse>
    {
        private readonly AuthBusinessRules _userBusinessRules;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(AuthBusinessRules userBusinessRules, ITokenHelper tokenHelper, IUserRepository userRepository)
        {
            _userBusinessRules = userBusinessRules;
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
 
            var user = await _userBusinessRules.UserShouldExistBeforeLogin(request.Email);

            _userBusinessRules.UserCredentialsMustMatchBeforeLogin(request.Password, user.PasswordHash,
                user.PasswordSalt);

            var operationClaims = user.UserOperationClaims.Select(p => p.OperationClaim);
            var claimList = new List<OperationClaim>();


            foreach (OperationClaim operationClaim in operationClaims)
            {
                claimList.Add(operationClaim);
            }

            AccessToken token=_tokenHelper.CreateToken(user, claimList);
            return new() { AccessToken = token };
        }
    }

    public sealed class LoginCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}
