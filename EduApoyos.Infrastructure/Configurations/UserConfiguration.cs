using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApoyos.Infrastructure.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property<Role>(p => p.Role).IsRequired();
            builder.Property(p => p.DateRegistration).IsRequired();
        }
    }
}
