using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Kodlama.io.Devs.Persistence.Contexts;

public sealed class KodlamaioDevsContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }


    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<GithubProfile> GithubProfiles { get; set; }






    public KodlamaioDevsContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(
        dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C"), new(2, "C++"), new(3, "C#") };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

        ProgrammingTechnology[] programmingTechnologyEntitySeeds =
            { new(1, 1, "Onion"), new(2, 2, "TreeFrog"), new(3, 3, "ASP.NET") };
        modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologyEntitySeeds);


        OperationClaim[] operationClaimSeeds = { new(1, "Admin"), new(2, "User") };
        modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeeds);
    }
}