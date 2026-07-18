using EduApoyos.Domain.Common.Enum;
using EduApoyos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApoyos.Infrastructure.Configurations
{
    public sealed class RequestSupportConfiguration : IEntityTypeConfiguration<RequestSupport>
    {
        public void Configure(EntityTypeBuilder<RequestSupport> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.StudentId).IsRequired();
            builder.Property<TypeSupport>(p => p.TypeSupport).IsRequired();
            builder.Property(p => p.RequestedAmount).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ApplicationDate).IsRequired();
            builder.Property(p => p.DateUpdated);
            builder.Property<Status>(p => p.Status).IsRequired();
            builder.Property(p => p.AdvisorId).IsRequired();

            builder.HasOne(m => m.Advisor).WithMany().HasForeignKey(fk => fk.AdvisorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Student).WithMany().HasForeignKey(fk => fk.StudentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
