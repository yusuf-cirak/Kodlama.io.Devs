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
    public sealed class ProgrammingLanguageConfiguration : BaseEntityConfiguration<ProgrammingLanguage>
    {
        public override void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            
            builder.ToTable("ProgrammingLanguages");

            builder.Property(pl => pl.Name).HasColumnName("Name").IsRequired();

            builder.HasMany(pl => pl.ProgrammingTechnologies);
        }
    }
}
