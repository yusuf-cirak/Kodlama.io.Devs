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
    public sealed class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.ToTable("ProgrammingLanguages").HasKey(k => k.Id);

            builder.Property(pl => pl.Id).HasColumnName("Id");

            builder.Property(pl => pl.Name).HasColumnName("Name").IsRequired();

            builder.HasMany(pl => pl.ProgrammingTechnologies);
        }
    }
}
