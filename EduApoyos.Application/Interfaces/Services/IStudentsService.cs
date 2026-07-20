using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IStudentsService
    {
        Task<int> CreateStudent(CreateStudentRequest createStudentRequest, CancellationToken cancellationToken);
        Task<ErrorOr<PaginatedList<GetStudentResult>>> GetStudents(GetStudentRequest request, CancellationToken cancellationToken);
        Task<ErrorOr<GetStudentResult?>> GetStudentByUserId(int studentId, CancellationToken cancellationToken);
        Task<ErrorOr<GetStudentResult?>> GetStudentById(int studentId, CancellationToken cancellationToken);
    }
}
