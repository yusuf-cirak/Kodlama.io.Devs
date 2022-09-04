using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<KodlamaioDevsContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("KodlamaioDevsSqlServer"));
        });

        services.AddScoped<IProgrammingLanguageRepository,ProgrammingLanguageRepository>();
    }
}