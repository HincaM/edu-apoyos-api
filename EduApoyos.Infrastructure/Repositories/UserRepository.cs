using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
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

        public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
            => await _users.FirstOrDefaultAsync(f => f.Email == email, cancellationToken);

        public async Task<PaginatedList<GetAdvisorResult>> GetAdvisors(GetAdvisorsSpecification specification, CancellationToken cancellationToken)
            => await _users
            .Where(u => u.Role == Role.Advisor)
            .OrderBy(specification.OrderBy)
            .Select(u => new GetAdvisorResult(u.Id, u.FullName))
            .ToPaginatedListAsync(specification.CurrentPage, specification.PageSize, cancellationToken);
    }
}
