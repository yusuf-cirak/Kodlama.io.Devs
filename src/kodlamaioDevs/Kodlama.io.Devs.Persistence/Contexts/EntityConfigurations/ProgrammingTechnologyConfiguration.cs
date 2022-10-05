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
    public sealed class ProgrammingTechnologyConfiguration : BaseEntityConfiguration<ProgrammingTechnology>
    {
        public override void Configure(EntityTypeBuilder<ProgrammingTechnology> builder)
        {
            builder.ToTable("ProgrammingTechnologies");

            builder.Property(pl => pl.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId").IsRequired();

            builder.Property(pl => pl.Name).HasColumnName("Name").IsRequired();

            builder.HasOne(pt => pt.ProgrammingLanguage);
        }
    }
}
