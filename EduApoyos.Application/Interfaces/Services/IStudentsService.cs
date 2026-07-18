using EduApoyos.Domain.Models;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IStudentsService
    {
        Task<int> CreateStudent(CreateStudentRequest createStudentRequest, CancellationToken cancellationToken);
        Task<ErrorOr<PaginatedList<GetStudentResult>>> GetStudents(GetStudentRequest request, CancellationToken cancellationToken);
    }
}
