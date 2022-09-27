using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Contexts.EntityConfigurations
{
    public sealed class GithubProfileConfiguration : IEntityTypeConfiguration<GithubProfile>
    {
        public void Configure(EntityTypeBuilder<GithubProfile> builder)
        {
            builder.ToTable("GithubProfiles").HasKey(g => g.Id);

            builder.Property(g => g.Id).HasColumnName("Id");

            builder.Property(g => g.UserId).HasColumnName("UserId");

            builder.Property(g => g.Login).HasColumnName("Login");

            builder.Property(g => g.HtmlUrl).HasColumnName("HtmlUrl");

            builder.Property(g => g.Name).HasColumnName("Name");

            builder.Property(g => g.Company).HasColumnName("Company");

            builder.Property(g => g.Blog).HasColumnName("Blog");

            builder.Property(g => g.Location).HasColumnName("Location");

            builder.Property(g => g.PublicRepos).HasColumnName("PublicRepos");

            builder.Property(g => g.Followers).HasColumnName("Followers");

            builder.Property(g => g.Following).HasColumnName("Following");

            builder.HasOne(g => g.User);
        }
    }
}
