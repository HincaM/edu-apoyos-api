using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;

public record GetRequestsSupportQuery(Status? Status, TypeSupport? Type, int CurrentPage, int PageSize) : IRequest<ErrorOr<PaginatedList<RequestSupportDto>>>;
