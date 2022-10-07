using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Contexts.EntityConfigurations
{
    public sealed class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");

            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();

            builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();

            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();

            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();

            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();

            builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatiorType");

            builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);


            builder.HasMany(u => u.RefreshTokens);

            builder.HasMany(u => u.UserOperationClaims);
        }
    }
}
