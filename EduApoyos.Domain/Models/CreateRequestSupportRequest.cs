using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record CreateRequestSupportRequest(
    int StudentId,
    int UserId,
    TypeSupport TypeSupport,
    double RequestedAmount,
    string Description,
    int AdvisorId
);
