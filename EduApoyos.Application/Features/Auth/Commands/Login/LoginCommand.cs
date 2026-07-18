namespace EduApoyos.Application.Features.Auth.Commands.Login;

public record LoginCommand(string UserId, string Password) : IRequest<ErrorOr<string>>;
