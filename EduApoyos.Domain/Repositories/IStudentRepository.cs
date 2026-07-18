using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Specifications;

namespace EduApoyos.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<int> Create(Student student, CancellationToken cancellationToken);
        Task<PaginatedList<Student>> GetStudents(GetStudentsSpecification specification, CancellationToken cancellationToken);
    }
}
