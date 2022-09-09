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
using Kodlama.io.Devs.Application.Features.Users.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandRequest:UserForLoginDto,IRequest<LoginUserCommandResponse>
    {
    }

    public class LoginUserCommandHandler:IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
    {
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(UserBusinessRules userBusinessRules, ITokenHelper tokenHelper, IUserRepository userRepository)
        {
            _userBusinessRules = userBusinessRules;
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.Query().Include(p => p.UserOperationClaims).ThenInclude(u=>u.OperationClaim)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            _userBusinessRules.UserShouldExistBeforeLogin(user);

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

    public class LoginUserCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}
