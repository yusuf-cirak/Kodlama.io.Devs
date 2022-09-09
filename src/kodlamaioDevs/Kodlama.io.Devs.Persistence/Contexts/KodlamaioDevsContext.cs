using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts;

public class KodlamaioDevsContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }


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



        ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C"), new(2, "C++"), new(3, "C#") };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

        ProgrammingTechnology[] programmingTechnologyEntitySeeds =
            { new(1, 1, "Onion"), new(2, 2, "TreeFrog"), new(3, 3, "ASP.NET") };
        modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologyEntitySeeds);
    }
}