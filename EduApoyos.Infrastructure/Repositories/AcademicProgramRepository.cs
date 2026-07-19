using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Repositories
{
    public sealed class AcademicProgramRepository(EduApoyosContext _context) : IAcademicProgramRepository
    {
        private readonly DbSet<AcademicProgram> _academicPrograms = _context.Set<AcademicProgram>();

        public async Task<PaginatedList<GetAcademicProgramResult>> GetAcademicPrograms(GetAcademicProgramsSpecification specification, CancellationToken cancellationToken)
            => await _academicPrograms
            .Where(specification.Criteria)
            .OrderBy(specification.OrderBy)
            .Select(a => new GetAcademicProgramResult(a.Id, a.Name, a.Description))
            .ToPaginatedListAsync(specification.CurrentPage, specification.PageSize, cancellationToken);
    }
}
