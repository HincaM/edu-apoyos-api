namespace EduApoyos.Domain.Models;

public record GetStudentResult(
    int Id, 
    string UserId, 
    string UserName,
    string DocumentNumber, 
    int AcademicProgramId, 
    string AcademicProgramName, 
    int Semester
    );
