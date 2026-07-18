using EduApoyos.Domain.Models;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using Mapster;

namespace EduApoyos.Application.Features.Students.Queries.GetStudents
{
    public sealed class GetStudentsQueryHandler(IStudentsService _studentsService) : IRequestHandler<GetStudentsQuery, ErrorOr<PaginatedList<StudentDto>>>
    {
        public async Task<ErrorOr<PaginatedList<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _studentsService.GetStudents(request.Adapt<GetStudentRequest>(), cancellationToken);

            if (result.IsError) return result.Errors;

            return result.Value.Adapt<PaginatedList<StudentDto>>();
        }
    }
}
