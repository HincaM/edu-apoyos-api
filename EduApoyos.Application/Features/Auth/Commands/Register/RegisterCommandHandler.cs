using EduApoyos.Application.Interfaces.Models;
using EduApoyos.Application.Interfaces.Services;
using Mapster;

namespace EduApoyos.Application.Features.Auth.Commands.Register
{
    public sealed class RegisterCommandHandler(IUserService _userService) : IRequestHandler<RegisterCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken) 
            => await _userService.Register(request.Adapt<RegisterRequest>(), cancellationToken);
    }
}
