using EduApoyos.Domain.Common.Enum;

namespace EduApoyos.Application.Features.Auth.Commands.Register;

public record RegisterCommand(string UserId, string FullName, string Email, string Password, Role Role) : IRequest<ErrorOr<bool>>;
