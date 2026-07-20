using FluentValidation;

namespace EduApoyos.Application.Features.Auth.Commands.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("El nombre de usuario es requerido.")
                .MaximumLength(200).WithMessage("La cantidad de caracteres para usuario es de máximo 200."); 

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es requerido.")
                .EmailAddress().WithMessage("Formato de correo inválido.")
                .MaximumLength(200).WithMessage("La cantidad de caracteres para usuario es de máximo 200.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es requerida.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("El rol es requerido.");
        }
    }
}
