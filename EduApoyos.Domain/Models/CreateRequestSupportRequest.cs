using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record CreateRequestSupportRequest(
    int StudentId,
    string UserId,
    TypeSupport TypeSupport,
    double RequestedAmount,
    string Description,
    string AdvisorId
);
