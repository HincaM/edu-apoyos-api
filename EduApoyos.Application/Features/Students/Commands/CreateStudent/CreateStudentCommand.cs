namespace EduApoyos.Application.Features.Students.Commands.CreateStudent;

public record CreateStudentCommand(string UserId, string DocumentNumber, int AcademicProgramId, int Semester) : IRequest<ErrorOr<int>>;
