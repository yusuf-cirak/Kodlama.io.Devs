using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Extensions;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Rules
{
    public class GithubProfileBusinessRules
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGithubProfileRepository _githubProfileRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public GithubProfileBusinessRules(IHttpClientFactory httpClientFactory, IGithubProfileRepository githubProfileRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _githubProfileRepository = githubProfileRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ReceivedGithubProfileDto> GithubProfileShouldExistBeforeAdded(string profileName)
        {
            HttpClient client = _httpClientFactory.CreateClient("GithubUserProfile");

            var profileDto = await client.GetFromJsonAsync<ReceivedGithubProfileDto>
                (requestUri: $"{client.BaseAddress}{profileName}");

            if (profileDto==null)
            {
                throw new BusinessException("No user exists with that profile name");
            }

            return profileDto;

        }

        public async Task<GithubProfile> GithubProfileShouldExistBeforeDeletedOrUpdated(int id)
        {
            GithubProfile? profile = await _githubProfileRepository.Query().AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);

            if (profile==null)
            {
                throw new BusinessException("No profile exists");
            }

            return profile;
        }
        public async Task<GithubProfile> CheckDbForGithubProfileBeforeUpdated(int id)
        {
            GithubProfile? profile = await _githubProfileRepository.Query().AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);

            if (profile == null)
            {
                throw new BusinessException("No profile exists");
            }

            return profile;
        }
        public void UserMustVerifiedBeforeProfileDeletedOrUpdated(int id)
        {
            var idFromToken=_httpContextAccessor.HttpContext.User.GetUserId();
            if (id!=idFromToken)
            {
                throw new AuthorizationException("You are not authorized");
            }
        }
    }
}
