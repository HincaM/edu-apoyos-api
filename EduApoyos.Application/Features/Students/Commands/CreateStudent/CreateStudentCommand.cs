using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Application.Features.Students.Commands.CreateStudent;

public record CreateStudentCommand(string UserId, string DocumentNumber, DocumentType DocumentType, int AcademicProgramId, int Semester) : IRequest<ErrorOr<int>>;
