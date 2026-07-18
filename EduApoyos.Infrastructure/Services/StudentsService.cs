using EduApoyos.Domain.Models;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using Mapster;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class StudentsService(IStudentRepository _studentRepository) : IStudentsService
    {
        public async Task<int> CreateStudent(CreateStudentRequest request, CancellationToken cancellationToken) 
            => await _studentRepository.Create(Student.Create(request.UserId, request.DocumentNumber, request.AcademicProgramId, request.Semester), cancellationToken);

        public async Task<ErrorOr<PaginatedList<GetStudentResult>>> GetStudents(GetStudentRequest request, CancellationToken cancellationToken)
            => await _studentRepository.GetStudents(new GetStudentsSpecification(request.CurrentPage, request.PageSize), cancellationToken);
    }
}
