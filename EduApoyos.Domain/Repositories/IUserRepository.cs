using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Specifications;

namespace EduApoyos.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Create(User user, CancellationToken cancellationToken);
        Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
        Task<PaginatedList<GetAdvisorResult>> GetAdvisors(GetAdvisorsSpecification specification, CancellationToken cancellationToken);

    }
}
