using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.AuthService
{
    public sealed class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            //refreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            //return refreshToken;
            return await _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id, include: u => u.Include(u => u.OperationClaim));

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(e => new OperationClaim(id: e.OperationClaim.Id, name: e.OperationClaim.Name)).ToList();

            //AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);

            return _tokenHelper.CreateToken(user, operationClaims); // AccessToken
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            //RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            ////return Task.FromResult(refreshToken);

            return Task.FromResult(_tokenHelper.CreateRefreshToken(user, ipAddress));
        }
    }
}
