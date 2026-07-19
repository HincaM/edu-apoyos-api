using BCrypt.Net;
using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Helpers;
using EduApoyos.Application.Interfaces.Services;

namespace EduApoyos.Application.Features.Auth.Commands.Login
{
    public sealed class LoginCommandHandler(
        IUserService _userService,
        TokenGeneratorHelper _tokenGeneratorHelper) : IRequestHandler<LoginCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.GetUserByEmail(request.Email, cancellationToken);
                if (user is null)
                    return Error.Unauthorized("Validación", "Usuario y/o contraseña incorrectos");

                PasswordHashHelper passwordHash = new();

                if (user.Email == request.Email && passwordHash.Verify(request.Password, user.PasswordHash))
                {
                    var token = _tokenGeneratorHelper.Generate(user.Email, user.Role);
                    return token;
                }

                return Error.Unauthorized("Validación", "Usuario y/o contraseña incorrectos");
            }
            catch(SaltParseException spe)
            {
                return Error.Unauthorized("Validación", "Usuario y/o contraseña incorrectos");
            }
        }
    }
}
