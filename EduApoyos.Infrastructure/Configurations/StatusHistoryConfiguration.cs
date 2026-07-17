using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApoyos.Infrastructure.Configurations
{
    public sealed class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
    {
        public void Configure(EntityTypeBuilder<StatusHistory> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property<Status>(p => p.PreviousState).IsRequired();
            builder.Property<Status>(p => p.NewState).IsRequired();
            builder.Property(p => p.ChangeDate).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RequestSupportId).IsRequired();

            builder.HasOne(m => m.User).WithMany().HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.RequestSupport).WithMany().HasForeignKey(fk => fk.RequestSupportId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
