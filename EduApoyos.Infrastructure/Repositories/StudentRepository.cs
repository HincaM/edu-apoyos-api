using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Repositories
{
    public sealed class StudentRepository(EduApoyosContext _context) : IStudentRepository
    {
        private readonly DbSet<Student> _students = _context.Set<Student>();

        public async Task<int> Create(Student student, CancellationToken cancellationToken)
        {
            await _students.AddAsync(student, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return student.Id;
        }

        public async Task<PaginatedList<Student>> GetStudents(GetStudentsSpecification specification, CancellationToken cancellationToken)
            => await _students.ToPaginatedList(specification.CurrentPage, specification.PageSize, cancellationToken);

    }
}
