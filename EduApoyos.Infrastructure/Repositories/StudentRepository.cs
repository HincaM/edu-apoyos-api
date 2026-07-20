using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Repositories
{
    public sealed class StudentRepository(EduApoyosContext _context) : IStudentRepository
    {
        private readonly DbSet<Student> _students = _context.Set<Student>();

        private IQueryable<GetStudentResult> GetQuery(ISpecification<Student> specification)
            => _students
                .Where(specification.Criteria)
                .Select(s => new GetStudentResult(
                    s.Id,
                    s.UserId,
                    s.User != null ? s.User.FullName : "",
                    s.DocumentNumber,
                    s.DocumentType,
                    s.AcademicProgramId,
                    s.AcademicProgram != null ? s.AcademicProgram.Name : "",
                    s.Semester
                    )
                );
        public async Task<int> Create(Student student, CancellationToken cancellationToken)
        {
            await _students.AddAsync(student, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return student.Id;
        }

        public async Task<GetStudentResult?> GetById(GetStudentByIdSpecification specification, CancellationToken cancellationToken)
            => await GetQuery(specification).FirstOrDefaultAsync(cancellationToken);

        public async Task<GetStudentResult?> GetByUserId(GetStudentByUserIdSpecification specification, CancellationToken cancellationToken)
            => await GetQuery(specification).FirstOrDefaultAsync(cancellationToken);

        public async Task<PaginatedList<GetStudentResult>> GetStudents(GetStudentsSpecification specification, CancellationToken cancellationToken)
            => await _students
            .OrderBy(specification.OrderBy)
            .Select(s => new GetStudentResult(
                s.Id,
                s.UserId,
                s.User != null ? s.User.FullName : "",
                s.DocumentNumber, 
                s.DocumentType, 
                s.AcademicProgramId,
                s.AcademicProgram != null ? s.AcademicProgram.Name : "",
                s.Semester
                ))
            .ToPaginatedListAsync(specification.CurrentPage, specification.PageSize, cancellationToken);

    }
}
