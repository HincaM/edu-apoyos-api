using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class AcademicProgramService(IAcademicProgramRepository _academicProgramRepository) : IAcademicProgramService
    {
        public async Task<ErrorOr<PaginatedList<GetAcademicProgramResult>>> GetAcademicPrograms(GetAcademicProgramRequest request, CancellationToken cancellationToken)
            => await _academicProgramRepository.GetAcademicPrograms(new GetAcademicProgramsSpecification(request.CurrentPage, request.PageSize), cancellationToken);
    }
}
