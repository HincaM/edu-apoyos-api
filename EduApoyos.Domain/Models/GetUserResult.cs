using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record GetUserResult(string Email, Role Role, string PasswordHash);
