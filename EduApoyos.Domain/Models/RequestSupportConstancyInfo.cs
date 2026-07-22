namespace EduApoyos.Domain.Models;

public record RequestSupportConstancyInfo(
    string DocumentTypeDescription, 
    string DocumentNumber, 
    string StudentName,
    string Email,
    string AcademicProgramName, 
    int Semester,
    string TypeSupportDescription,
    double RequestedAmount,
    string Description,
    string StatusDescription,
    DateTime ApplicationDate
    );

