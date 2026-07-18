using EduApoyos.Domain.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken);
    }
}
