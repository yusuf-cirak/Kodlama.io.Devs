using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Features.Auths.Rules;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Kodlama.io.Devs.Application.Services.UserOperationClaimService;
using Kodlama.io.Devs.Application.Services.AuthService;

namespace Kodlama.io.Devs.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

       
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();

            services.AddScoped<IAuthService, AuthManager>();

            // Business Rules

            services.AddScoped<ProgrammingLanguageBusinessRules>();

            services.AddScoped<ProgrammingTechnologyBusinessRules>();

            services.AddScoped<AuthBusinessRules>();

            services.AddScoped<GithubProfileBusinessRules>();




            // FluentValidation dependency injection
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));;

            // Authorization
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        }
    }
}
