using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models;

public record ChangeStatusRequestSupportRequest(int RequestSupportId, Status CurrentStatus, Status Status, string? Observation);
