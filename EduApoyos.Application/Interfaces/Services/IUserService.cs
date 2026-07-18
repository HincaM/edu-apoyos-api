using EduApoyos.Domain.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<GetUserResult?> GetUserById(string userId, CancellationToken cancellationToken);
        Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken);
    }
}
