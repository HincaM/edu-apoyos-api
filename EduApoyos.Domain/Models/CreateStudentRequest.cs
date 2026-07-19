namespace EduApoyos.Domain.Models;

public record CreateStudentRequest(int UserId, string DocumentNumber, int AcademicProgramId, int Semester);