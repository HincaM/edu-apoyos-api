using EduApoyos.Domain.Common.Enum;
using EduApoyos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApoyos.Infrastructure.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(200);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.PasswordHash).IsRequired().HasMaxLength(256);
            builder.Property<Role>(p => p.Role).IsRequired();
            builder.Property(p => p.DateRegistration).IsRequired();
        }
    }
}
