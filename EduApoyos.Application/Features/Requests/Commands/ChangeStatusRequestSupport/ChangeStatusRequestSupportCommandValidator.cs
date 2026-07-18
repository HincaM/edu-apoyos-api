using FluentValidation;

namespace EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport
{
    public sealed class ChangeStatusRequestSupportCommandValidator: AbstractValidator<ChangeStatusRequestSupportCommand>
    {
        public ChangeStatusRequestSupportCommandValidator()
        {
            RuleFor(x => x.RequestSupportId).NotEmpty().WithMessage("El id de solicitud de soporte es requerido.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("El nuevo estado de la solicitud de soporte es requerido.");
        }
    }
}
