using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IAcademicProgramService
    {
        Task<ErrorOr<PaginatedList<GetAcademicProgramResult>>> GetAcademicPrograms(GetAcademicProgramRequest request, CancellationToken cancellationToken);
    }
}
