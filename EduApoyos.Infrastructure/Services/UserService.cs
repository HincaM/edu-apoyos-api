using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using Mapster;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class UserService(IUserRepository _userRepository) : IUserService
    {
        public async Task<GetUserResult?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return (await _userRepository.GetByEmail(email, cancellationToken)).Adapt<GetUserResult>(config =>
            {
                config.NewConfig<User, GetUserResult>()
                    .Map(dest => dest.Email, src => src.Email)
                    .Map(dest => dest.Role, src => src.Role)
                    .Map(dest => dest.PasswordHash, src => src.PasswordHash);
            });
        }

        public async Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            PasswordHashHelper passwordHash = new();
            var passHash = passwordHash.Hash(request.Password);
            return await _userRepository.Create(User.Create(request.FullName, request.Email, passHash, request.Role), cancellationToken);
        }

        public async Task<ErrorOr<PaginatedList<GetAdvisorResult>>> GetAdvisors(GetAdvisorRequest request, CancellationToken cancellationToken)
            => await _userRepository.GetAdvisors(new GetAdvisorsSpecification(request.CurrentPage, request.PageSize), cancellationToken);
    }
}
