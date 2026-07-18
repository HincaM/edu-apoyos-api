using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Repositories;
using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Repositories
{
    public sealed class UserRepository(EduApoyosContext _context) : IUserRepository
    {
        private readonly DbSet<User> _users = _context.Set<User>();

        public async Task<bool> Create(User user, CancellationToken cancellationToken)
        {
            await _users.AddAsync(user, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<User?> GetById(string userId, CancellationToken cancellationToken) 
            => await _users.FirstOrDefaultAsync(f => f.Id == userId, cancellationToken);
    }
}
