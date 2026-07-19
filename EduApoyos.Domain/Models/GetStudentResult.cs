namespace EduApoyos.Domain.Models;

public record GetStudentResult(
    int Id, 
    int UserId, 
    string UserName,
    string DocumentNumber, 
    int AcademicProgramId, 
    string AcademicProgramName, 
    int Semester
    );
