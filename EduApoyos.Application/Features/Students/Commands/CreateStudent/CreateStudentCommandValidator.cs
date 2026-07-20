using FluentValidation;

namespace EduApoyos.Application.Features.Students.Commands.CreateStudent
{
    public sealed class CreateStudentCommandValidator: AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El número de documento es requerido.");

            RuleFor(x => x.DocumentType)
                .IsInEnum().WithMessage("El tipo de documento es requerido.");

            RuleFor(x => x.AcademicProgramId)
                .NotEmpty().WithMessage("El ID del programa académico es requerido.");

            RuleFor(x => x.Semester)
                .NotEmpty().WithMessage("El semestre es requerido.")
                .GreaterThan(0).WithMessage("El semestre es requerido.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("El ID del usuario es requerido.");
        }
    }
}
