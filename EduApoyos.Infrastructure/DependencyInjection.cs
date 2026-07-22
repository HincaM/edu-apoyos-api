using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Services;
using EduApoyos.Infrastructure.Context;
using EduApoyos.Infrastructure.Repositories;
using EduApoyos.Infrastructure.Services;
using EduApoyos.Infrastructure.Services.External;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduApoyos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string nameConnectionString)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();


            return services
                .AddDbContext<EduApoyosContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString(nameConnectionString));
                    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                })
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IRequestSupportRepository, RequestSupportRepository>()
                .AddScoped<IAcademicProgramRepository, AcademicProgramRepository>()
                .AddScoped<IStatusHistoryRepository, StatusHistoryRepository>()

                .AddScoped<IStudentsService, StudentsService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IRequestSupportService, RequestSupportService>()
                .AddScoped<IAcademicProgramService, AcademicProgramService>()
                .AddScoped<IManagementFilesService, ManagementFilesService>()
                ;
        }   
    }
}
