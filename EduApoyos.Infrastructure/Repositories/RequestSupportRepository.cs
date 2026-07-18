using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using EduApoyos.Domain.Specifications.RequestsSupports;
using EduApoyos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Repositories
{
    public sealed class RequestSupportRepository(EduApoyosContext _context) : IRequestSupportRepository
    {
        private readonly DbSet<RequestSupport> _requestSupports = _context.Set<RequestSupport>();

        public async Task<int> Create(RequestSupport requestSupport, CancellationToken cancellationToken)
        {
            await _requestSupports.AddAsync(requestSupport, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return requestSupport.Id;
        }

        private IQueryable<RequestSupport> GetQuery(ISpecification<RequestSupport> specification) 
            => _requestSupports.Where(specification.Criteria);

        public async Task<PaginatedList<GetRequestsSupportResult>> GetRequests(GetRequestSupportSpecification specification, CancellationToken cancellationToken)
        {
            return await GetQuery(specification)
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

        public async Task<GetRequestsSupportResult?> GetRequestById(GetRequestSupportByIdSpecification specification, CancellationToken cancellationToken)
        {
            return await GetQuery(specification)
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
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> ChangeStatus(int requestSupportId, Status status, CancellationToken cancellationToken)
        {
            var query = GetQuery(new GetRequestSupportByIdSpecification(requestSupportId));

            if (await query.AnyAsync(cancellationToken))
                return await query.ExecuteUpdateAsync(upd => upd.SetProperty(p => p.Status, status), cancellationToken) > 0;

            return false;
        }
    }
}
