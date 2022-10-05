using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Contexts.EntityConfigurations
{
    public sealed class OperationClaimConfiguration : BaseEntityConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("OperationClaims");

            builder.Property(o => o.Name).HasColumnName("Name").IsRequired();
        }
    }
}
