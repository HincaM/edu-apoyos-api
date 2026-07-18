using EduApoyos.Application.Interfaces.Models;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using Mapster;

namespace EduApoyos.Application.Features.Students.Queries.GetStudents
{
    public sealed class GetStudentsQueryHandler(IStudentsService _studentsService) : IRequestHandler<GetStudentsQuery, ErrorOr<PaginatedList<StudentDto>>>
    {
        public async Task<ErrorOr<PaginatedList<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken) 
            => (await _studentsService.GetStudents(request.Adapt<StudentRequest>(), cancellationToken)).Adapt<PaginatedList<StudentDto>>();
    }
}
