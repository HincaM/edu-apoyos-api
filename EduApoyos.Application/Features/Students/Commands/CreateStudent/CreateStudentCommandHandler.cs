using EduApoyos.Domain.Models;
using EduApoyos.Application.Interfaces.Services;
using Mapster;

namespace EduApoyos.Application.Features.Students.Commands.CreateStudent
{
    public sealed class CreateStudentCommandHandler(IStudentsService _studentsService) : IRequestHandler<CreateStudentCommand, ErrorOr<int>>
    {
        public async Task<ErrorOr<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken) 
            => await _studentsService.CreateStudent(request.Adapt<CreateStudentRequest>(), cancellationToken);
    }
}
