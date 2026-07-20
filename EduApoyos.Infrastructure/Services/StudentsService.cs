using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class StudentsService(IStudentRepository _studentRepository) : IStudentsService
    {
        public async Task<int> CreateStudent(CreateStudentRequest request, CancellationToken cancellationToken) 
            => await _studentRepository.Create(Student.Create(request.UserId, request.DocumentNumber, request.DocumentType, request.AcademicProgramId, request.Semester), cancellationToken);

        public async Task<ErrorOr<GetStudentResult?>> GetStudentById(int studentId, CancellationToken cancellationToken)
            => await _studentRepository.GetById(new GetStudentByIdSpecification(studentId), cancellationToken);

        public async Task<ErrorOr<GetStudentResult?>> GetStudentByUserId(int userId, CancellationToken cancellationToken)
            => await _studentRepository.GetByUserId(new GetStudentByUserIdSpecification(userId), cancellationToken);

        public async Task<ErrorOr<PaginatedList<GetStudentResult>>> GetStudents(GetStudentRequest request, CancellationToken cancellationToken)
            => await _studentRepository.GetStudents(new GetStudentsSpecification(request.CurrentPage, request.PageSize), cancellationToken);
    }
}
