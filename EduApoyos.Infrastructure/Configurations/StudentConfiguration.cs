using EduApoyos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApoyos.Infrastructure.Configurations
{
    public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Semester).IsRequired();
            builder.Property(p => p.DocumentNumber).IsRequired().HasMaxLength(30);
            builder.Property(p => p.DocumentType).IsRequired();
            builder.Property(p => p.AcademicProgramId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.HasOne(m => m.User).WithMany().HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.AcademicProgram).WithMany().HasForeignKey(fk => fk.AcademicProgramId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
