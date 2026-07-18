using EduApoyos.Application.Interfaces.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken);
    }
}
