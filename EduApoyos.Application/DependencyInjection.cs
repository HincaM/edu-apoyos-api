using EduApoyos.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
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
                ;
        }
    }
}
