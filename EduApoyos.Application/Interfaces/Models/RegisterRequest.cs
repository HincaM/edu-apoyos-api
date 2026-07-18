using EduApoyos.Domain.Common.Enum;

namespace EduApoyos.Application.Interfaces.Models;

public record RegisterRequest(string UserId, string FullName, string Email, string Password, Role Role);
