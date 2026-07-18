using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Api.Helpers
{
    public class ApplyMigrationHelper
    {
        public static void Apply(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<EduApoyosContext>();
                    context.Database.Migrate();

                    if (app.Environment.IsDevelopment())
                        DbInitializer.Seed(context);
                }
                catch (Exception ex)
                {
                   var logger = services.GetRequiredService<ILogger<ApplyMigrationHelper>>();
                    logger.LogError(ex, "Ocurrió un error al migrar la base de datos.");
                }
            }
        }
    }
}
