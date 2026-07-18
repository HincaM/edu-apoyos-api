using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequestsSupportByStudentId
{
    public record GetRequestsSupportByStudentIdQuery(int StudentId, int CurrentPage, int PageSize) : IRequest<ErrorOr<PaginatedList<RequestSupportDto>>>;
}
