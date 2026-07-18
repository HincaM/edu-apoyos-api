using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using Mapster;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class UserService(IUserRepository _userRepository) : IUserService
    {
        public async Task<GetUserResult?> GetUserById(string userId, CancellationToken cancellationToken)
        {
            return (await _userRepository.GetById(userId, cancellationToken)).Adapt<GetUserResult>(config =>
            {
                config.NewConfig<User, GetUserResult>()
                    .Map(dest => dest.UserId, src => src.Id)
                    .Map(dest => dest.Email, src => src.Email)
                    .Map(dest => dest.Role, src => src.Role)
                    .Map(dest => dest.PasswordHash, src => src.PasswordHash);
            });
        }

        public async Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            PasswordHashHelper passwordHash = new();
            var passHash = passwordHash.Hash(request.Password);
            return await _userRepository.Create(User.Create(request.UserId, request.FullName, request.Email, passHash, request.Role), cancellationToken);
        }
    }
}
