using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record GetStudentResult(
    int Id,
    int UserId,
    string UserName,
    string DocumentNumber,
    DocumentType DocumentType,
    int AcademicProgramId,
    string AcademicProgramName,
    int Semester
    );
