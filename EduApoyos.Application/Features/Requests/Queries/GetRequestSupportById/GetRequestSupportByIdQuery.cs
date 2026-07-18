using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequestSupportById;

public record GetRequestSupportByIdQuery(int Id) : IRequest<ErrorOr<RequestSupportDto>>;
