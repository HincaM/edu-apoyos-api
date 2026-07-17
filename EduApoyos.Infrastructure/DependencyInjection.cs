using EduApoyos.Domain.Repositories;
using EduApoyos.Infrastructure.Context;
using EduApoyos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EduApoyos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string nameConnectionString)
        {
            return services
                .AddDbContext<EduApoyosContext>(opt => opt.UseSqlServer($"name=ConnectionStrings:{nameConnectionString}"))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IRequestSupportRepository, RequestSupportRepository>()
                ;
        }   
    }
}
