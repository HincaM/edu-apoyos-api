using BCrypt.Net;
using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Helpers;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Application.Features.Auth.Commands.Login
{
    public sealed class LoginCommandHandler(
        IUserService _userService,
        IStudentsService _studentsService,
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
                    string? studentId = null;
                    if(user.Role == Role.Student)
                    {
                        var student = await _studentsService.GetStudentByUserId(user.UserId, cancellationToken);
                        studentId = student.Value?.Id.ToString();
                    }
                    var token = _tokenGeneratorHelper.Generate(user.UserId, user.Email, user.Role, studentId);
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
