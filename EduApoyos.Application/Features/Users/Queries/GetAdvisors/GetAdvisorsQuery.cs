using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Features.Users.Queries.GetAdvisors
{
    public record GetAdvisorsQuery(int CurrentPage, int PageSize) : IRequest<ErrorOr<PaginatedList<AdvisorDto>>>;
}
