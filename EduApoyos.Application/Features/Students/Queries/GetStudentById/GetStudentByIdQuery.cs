using EduApoyos.Application.Features.Students.Queries.GetStudents;

namespace EduApoyos.Application.Features.Students.Queries.GetStudentById;

public record GetStudentByIdQuery(int StudentId) : IRequest<ErrorOr<StudentDto>>;
