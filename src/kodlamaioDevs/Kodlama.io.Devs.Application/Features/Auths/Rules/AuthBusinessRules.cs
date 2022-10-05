using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Auths.Rules
{
    public sealed class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCannotBeDuplicatedBeforeRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user!=null)
            {
                throw new BusinessException("A user already exists with that email");
            }
        }


        public void UserCredentialsMustMatchBeforeLogin(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password,passwordHash,passwordSalt))
            {
                throw new BusinessException("Wrong credentials");
            }
        }

        public async Task<User> UserShouldExistBeforeLogin(string email)
        {
            User? user = await _userRepository.Query().Include(p => p.UserOperationClaims).ThenInclude(u => u.OperationClaim)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user==null)
            {
                throw new BusinessException("User is null");
            }

            return user;
        }
    }
}
