using FluentValidation;

namespace EduApoyos.Application.Features.Requests.Commands.CreateRequest
{
    public sealed class CreateRequestSupportCommandValidator: AbstractValidator<CreateRequestSupportCommand>
    {
        public CreateRequestSupportCommandValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("El estudiante es obligatorio.");

            RuleFor(x => x.TypeSupport)
                .NotEmpty().WithMessage("El tipo de apoyo es requerido.");

            RuleFor(x => x.RequestedAmount)
                .NotEmpty().WithMessage("El monto solicitado es requerido.")
                .GreaterThan(0).WithMessage("El monto solicitado debe ser un valor mayor a cero.");

            RuleFor(x => x.AdvisorId)
                .NotEmpty().WithMessage("El asesor es requerido.");
        }
    }
}
