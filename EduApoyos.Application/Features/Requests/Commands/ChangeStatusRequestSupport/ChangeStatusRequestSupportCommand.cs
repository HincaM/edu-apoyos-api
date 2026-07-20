using EduApoyos.Domain.Common.Enums;
using System.Text.Json.Serialization;

namespace EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport;

public record ChangeStatusRequestSupportCommand([property: JsonIgnore] int RequestSupportId, Status CurrentStatus, Status Status, string? Observation): IRequest<ErrorOr<bool>>;
