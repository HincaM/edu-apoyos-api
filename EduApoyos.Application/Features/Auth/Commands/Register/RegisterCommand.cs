using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Application.Features.Auth.Commands.Register;

public record RegisterCommand(string DocumentNumber,
    DocumentType DocumentType,
    int AcademicProgramId,
    int Semester,
    string FullName,
    string Email,
    string Password,
    Role Role
    ) : IRequest<ErrorOr<bool>>;
