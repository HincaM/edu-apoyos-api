using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Application.Features.Requests.Commands.CreateRequest;
public record CreateRequestSupportCommand(
    int StudentId,
    string UserId,
    TypeSupport TypeSupport,
    double RequestedAmount,
    string Description,
    string AdvisorId
    ) : IRequest<ErrorOr<int>>;