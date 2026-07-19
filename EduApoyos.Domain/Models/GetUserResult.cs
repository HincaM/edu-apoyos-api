using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record GetUserResult(int UserId, string Email, Role Role, string PasswordHash);
