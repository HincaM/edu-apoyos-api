using EduApoyos.Domain.Entities;

namespace EduApoyos.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Create(User user, CancellationToken cancellationToken);
        Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
