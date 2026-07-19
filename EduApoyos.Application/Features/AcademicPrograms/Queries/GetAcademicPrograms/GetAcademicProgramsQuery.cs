using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Features.AcademicPrograms.Queries.GetAcademicPrograms
{
    public record GetAcademicProgramsQuery(int CurrentPage, int PageSize) : IRequest<ErrorOr<PaginatedList<AcademicProgramDto>>>;
}
