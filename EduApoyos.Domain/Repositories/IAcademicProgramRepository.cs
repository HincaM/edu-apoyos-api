using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Specifications;

namespace EduApoyos.Domain.Repositories
{
    public interface IAcademicProgramRepository
    {
        Task<PaginatedList<GetAcademicProgramResult>> GetAcademicPrograms(GetAcademicProgramsSpecification specification, CancellationToken cancellationToken);
    }
}
