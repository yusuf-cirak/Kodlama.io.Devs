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
    public sealed class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(u => u.Id);

            builder.Property(uop => uop.Id).HasColumnName("Id");

            builder.Property(uop => uop.UserId).HasColumnName("UserId").IsRequired();

            builder.Property(uop => uop.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            builder.HasOne(uop => uop.OperationClaim);

            builder.HasOne(uop => uop.User);
        }
    }
}
