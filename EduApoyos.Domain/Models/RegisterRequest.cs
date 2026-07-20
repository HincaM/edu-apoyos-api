using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record RegisterRequest(
    string DocumentNumber,
    DocumentType DocumentType,
    int AcademicProgramId,
    int Semester,
    string FullName,
    string Email,
    string Password,
    Role Role);
