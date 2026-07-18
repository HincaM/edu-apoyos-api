namespace EduApoyos.Application.Features.Auth.Commands.Login;

public record LoginCommand() : IRequest<ErrorOr<string>>;
