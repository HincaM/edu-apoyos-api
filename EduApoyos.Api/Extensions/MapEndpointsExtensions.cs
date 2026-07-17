using EduApoyos.Api.Helpers;

namespace EduApoyos.Api.Extensions
{
    public static class MapEndpointsExtensions
    {
        public static IEndpointRouteBuilder MapEndpointsModule(this IEndpointRouteBuilder app)
        {
            var modules = typeof(Program).Assembly
                .GetTypes()
                .Where(t => typeof(IEndpointsModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointsModule>();

            foreach (var module in modules)
            {
                module.Register(app);
            }
            return app;
        }
    }
}
