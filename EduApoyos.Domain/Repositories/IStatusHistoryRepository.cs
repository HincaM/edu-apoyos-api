using EduApoyos.Domain.Entities;

namespace EduApoyos.Domain.Repositories
{
    public interface IStatusHistoryRepository
    {
        Task<bool> Create(StatusHistory statusHistory, CancellationToken cancellationToken);
    }
}
