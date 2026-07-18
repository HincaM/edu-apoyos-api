using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Features.Students.Queries.GetStudents;

public record GetStudentsQuery(int CurrentPage, int PageSize) : IRequest<ErrorOr<PaginatedList<StudentDto>>>;
