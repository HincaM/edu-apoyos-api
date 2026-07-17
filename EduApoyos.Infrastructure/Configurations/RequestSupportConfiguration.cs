using EduApoyos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApoyos.Infrastructure.Configurations
{
    public sealed class RequestSupportConfiguration : IEntityTypeConfiguration<RequestSupport>
    {
        public void Configure(EntityTypeBuilder<RequestSupport> builder)
        {
            throw new NotImplementedException();
        }
    }
}
