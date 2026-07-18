namespace EduApoyos.Domain.Models;

public record CreateStudentRequest(string UserId, string DocumentNumber, int AcademicProgramId, int Semester);