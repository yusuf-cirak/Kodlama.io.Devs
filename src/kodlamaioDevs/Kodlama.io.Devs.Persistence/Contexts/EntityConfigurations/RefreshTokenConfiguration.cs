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
    public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens").HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id).HasColumnName("Id");
            builder.Property(rt => rt.UserId).HasColumnName("UserId");
            builder.Property(rt => rt.Expires).HasColumnName("Expires");
            builder.Property(rt => rt.Created).HasColumnName("Created");
            builder.Property(rt => rt.CreatedByIp).HasColumnName("CreatedByIp");
            builder.Property(rt => rt.Revoked).HasColumnName("Revoked").IsRequired(false);
            builder.Property(rt => rt.RevokedByIp).HasColumnName("RevokedByIp").IsRequired(false);
            builder.Property(rt => rt.ReplacedByToken).HasColumnName("ReplacedByToken").IsRequired(false);
            builder.Property(rt => rt.ReasonRevoked).HasColumnName("ReasonRevoked").IsRequired(false);

            builder.HasOne(rt => rt.User).WithMany(u => u.RefreshTokens).HasForeignKey(uop => uop.UserId);
        }
    }
}
