using EduApoyos.Application.Common.Behaviours;
using EduApoyos.Application.Common.Middlewares;
using EduApoyos.Application.Helpers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EduApoyos.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly))
                .AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ErrorOrBehaviour<,>))
                .AddScoped<TokenGeneratorHelper>()
                .AddTransient<ExceptionMiddleware>()
                ;
        }
    }
}
