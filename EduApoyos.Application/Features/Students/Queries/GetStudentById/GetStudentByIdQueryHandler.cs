using EduApoyos.Application.Features.Students.Queries.GetStudents;
using EduApoyos.Application.Interfaces.Services;
using Mapster;

namespace EduApoyos.Application.Features.Students.Queries.GetStudentById
{
    public sealed class GetStudentByIdQueryHandler(IStudentsService _studentsService) : IRequestHandler<GetStudentByIdQuery, ErrorOr<StudentDto>>
    {
        public async Task<ErrorOr<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _studentsService.GetStudentById(request.StudentId, cancellationToken);
            if (result.IsError) return result.Errors;

            if (result.Value is null) return Error.NotFound("Estudiante", "Estudiante no encontrado.");

            return result.Value.Adapt<StudentDto>();
        }
    }
}
