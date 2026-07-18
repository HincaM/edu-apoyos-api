using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequests;

public record GetRequestsQuery(Status? Status, TypeSupport? Type, int CurrentPage, int PageSize) : IRequest<ErrorOr<PaginatedList<RequestSupportDto>>>;
