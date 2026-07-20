using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequestsSupportByStudentId
{
    public record GetRequestsSupportByStudentIdQuery(Status? Status, TypeSupport? Type, int StudentId, int CurrentPage, int PageSize) : IRequest<ErrorOr<PaginatedList<RequestSupportDto>>>;
}
