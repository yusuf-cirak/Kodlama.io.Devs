using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts;

public class KodlamaioDevsContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }


    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }





    public KodlamaioDevsContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(
        dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(a =>
        {
            a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            a.Property(pl => pl.Id).HasColumnName("Id");
            a.Property(pl => pl.Name).HasColumnName("Name");

            a.HasMany(pl => pl.ProgrammingTechnologies);
        });


        modelBuilder.Entity<ProgrammingTechnology>(a =>
        {
            a.ToTable("ProgrammingTechnologies").HasKey(pt => pt.Id);
            a.Property(pl => pl.Id).HasColumnName("Id");
            a.Property(pl => pl.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            a.Property(pl => pl.Name).HasColumnName("Name");

            a.HasOne(pt => pt.ProgrammingLanguage);

        });

        modelBuilder.Entity<User>(a =>
        {
            a.ToTable("Users").HasKey(u => u.Id);
            a.Property(u => u.Id).HasColumnName("Id");
            a.Property(u => u.FirstName).HasColumnName("FirstName");
            a.Property(u => u.LastName).HasColumnName("LastName");
            a.Property(u => u.Email).HasColumnName("Email");
            a.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
            a.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
            a.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatiorType");
            a.Property(u => u.Status).HasColumnName("Status");

            a.HasMany(u => u.RefreshTokens);
            a.HasMany(u => u.UserOperationClaims);
        });

        modelBuilder.Entity<OperationClaim>(a =>
        {
            a.ToTable("OperationClaims").HasKey(o => o.Id);
            a.Property(o => o.Id).HasColumnName("Id");
            a.Property(o => o.Name).HasColumnName("Name");

        });

        modelBuilder.Entity<UserOperationClaim>(a =>
        {
            a.ToTable("UserOperationClaims").HasKey(u => u.Id);
            a.Property(uop => uop.Id).HasColumnName("Id");
            a.Property(uop => uop.UserId).HasColumnName("UserId");
            a.Property(uop => uop.OperationClaimId).HasColumnName("OperationClaimId");

            a.HasOne(uop => uop.OperationClaim);
            a.HasOne(uop => uop.User);


        });



        ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C"), new(2, "C++"), new(3, "C#") };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

        ProgrammingTechnology[] programmingTechnologyEntitySeeds =
            { new(1, 1, "Onion"), new(2, 2, "TreeFrog"), new(3, 3, "ASP.NET") };
        modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologyEntitySeeds);


        OperationClaim[] operationClaimSeeds = { new(1, "Admin"), new(2, "User") };
        modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeeds);
    }
}