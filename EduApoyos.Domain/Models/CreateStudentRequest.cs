using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record CreateStudentRequest(int UserId, string DocumentNumber, DocumentType DocumentType, int AcademicProgramId, int Semester);