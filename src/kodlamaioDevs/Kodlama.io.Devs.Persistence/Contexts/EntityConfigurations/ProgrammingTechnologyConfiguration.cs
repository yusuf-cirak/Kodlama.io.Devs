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
    public sealed class ProgrammingTechnologyConfiguration : IEntityTypeConfiguration<ProgrammingTechnology>
    {
        public void Configure(EntityTypeBuilder<ProgrammingTechnology> builder)
        {
            builder.ToTable("ProgrammingTechnologies").HasKey(pt => pt.Id);

            builder.Property(pl => pl.Id).HasColumnName("Id");

            builder.Property(pl => pl.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId").IsRequired();

            builder.Property(pl => pl.Name).HasColumnName("Name").IsRequired();

            builder.HasOne(pt => pt.ProgrammingLanguage);
        }
    }
}
