using EduApoyos.Domain.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<GetUserResult?> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken);
    }
}
