using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Specifications.Students;

namespace EduApoyos.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<int> Create(Student student, CancellationToken cancellationToken);
        Task<GetStudentResult?> GetById(GetStudentByIdSpecification specification, CancellationToken cancellationToken);
        Task<GetStudentResult?> GetByUserId(GetStudentByUserIdSpecification specification, CancellationToken cancellationToken);
        Task<PaginatedList<GetStudentResult>> GetStudents(GetStudentsSpecification specification, CancellationToken cancellationToken);
    }
}
