using EduApoyos.Domain.Models;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Repositories;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class UserService(IUserRepository _userRepository) : IUserService
    {
        public async Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken) 
            => await _userRepository.Create(User.Create(request.UserId, request.FullName, request.Email, request.Password, request.Role), cancellationToken);
    }
}
