using EduApoyos.Domain.Models;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Repositories
{
    public sealed class RequestSupportRepository(EduApoyosContext _context) : IRequestSupportRepository
    {
        private readonly DbSet<RequestSupport> _requestSupports = _context.Set<RequestSupport>();

        public async Task<PaginatedList<GetRequestsSupportResult>> GetRequests(GetRequestSupportSpecification specification, CancellationToken cancellationToken)
        {
            return await _requestSupports
                .Where(specification.Criteria)
                .OrderByDescending(specification.OrderByDesc)
                .Select(s => new GetRequestsSupportResult
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    StudentName = s.Student != null && s.Student.User != null ? s.Student.User.FullName : null,
                    TypeSupport = s.TypeSupport,
                    RequestedAmount = s.RequestedAmount,
                    Description = s.Description,
                    Status = s.Status,
                    ApplicationDate = s.ApplicationDate,
                    DateUpdated = s.DateUpdated,
                    AdvisorId = s.AdvisorId,
                    AdvisorName = s.Advisor != null ? s.Advisor.FullName : null
                })
                .ToPaginatedListAsync(specification.CurrentPage, specification.PageSize, cancellationToken);
        }
    }
}
