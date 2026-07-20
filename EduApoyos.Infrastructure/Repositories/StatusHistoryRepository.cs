using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Repositories;
using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Repositories
{
    public sealed class StatusHistoryRepository(EduApoyosContext _context) : IStatusHistoryRepository
    {
        private readonly DbSet<StatusHistory> _statusHistories = _context.Set<StatusHistory>();
        public async Task<bool> Create(StatusHistory statusHistory, CancellationToken cancellationToken)
        {
            await _statusHistories.AddAsync(statusHistory, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
