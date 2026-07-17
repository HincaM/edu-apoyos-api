using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Context
{
    public class EduApoyosContext(DbContextOptions<EduApoyosContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduApoyosContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
