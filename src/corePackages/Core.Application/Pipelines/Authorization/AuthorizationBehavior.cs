using System.Reflection;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
                                        RequestHandlerDelegate<TResponse> next)
    {
        List<string> roleClaimsFromToken = _httpContextAccessor.HttpContext.User.ClaimRoles()!;

        if (roleClaimsFromToken == null) throw new AuthorizationException("Claims not found.");


        string[]? roleClaimsFromAttribute = request.GetType().GetCustomAttribute<AuthorizeAttribute>()?.Roles;


        if (roleClaimsFromAttribute == null) throw new AuthorizationException("Claims not found.");


        bool isNotMatchedARoleClaimWithRequestRoles =
            roleClaimsFromToken.FirstOrDefault(roleClaim => roleClaimsFromAttribute.Any(role => role == roleClaim)).IsNullOrEmpty();
        if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.");

        TResponse response = await next();
        return response;
    }
}