using EduApoyos.Application.Interfaces.Models;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IStudentsService
    {
        Task<int> CreateStudent(CreateStudentRequest createStudentRequest, CancellationToken cancellationToken);
        Task<ErrorOr<PaginatedList<StudentResult>>> GetStudents(StudentRequest request, CancellationToken cancellationToken);
    }
}
