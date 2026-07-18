using EduApoyos.Api.Helpers;
using EduApoyos.Application.Features.Auth.Commands.Login;
using EduApoyos.Application.Features.Auth.Commands.Register;
using MediatR;

namespace EduApoyos.Api.Endpoints
{
    public sealed class AuthenticationEndpoints : IEndpointsModule
    {
        public void Register(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/auth").WithTags("Authentication");

            group.MapPost("login", Login);
            group.MapPost("register", UserRegister);
        }

        private static async Task<IResult> Login(LoginCommand command, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(command, cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> UserRegister(RegisterCommand command, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(command, cancellationToken)).Match(Results.Ok, Problem);
    }
}
