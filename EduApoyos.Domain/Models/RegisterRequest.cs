using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record RegisterRequest(string FullName, string Email, string Password, Role Role);
