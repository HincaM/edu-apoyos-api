using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Specifications.RequestsSupports;

namespace EduApoyos.Domain.Repositories
{
    public interface IRequestSupportRepository
    {
        Task<int> Create(RequestSupport requestSupport, CancellationToken cancellationToken);
        Task<PaginatedList<GetRequestsSupportResult>> GetRequests(GetRequestSupportSpecification specification, CancellationToken cancellationToken);
        Task<GetRequestsSupportResult?> GetRequestById(GetRequestSupportByIdSpecification specification, CancellationToken cancellationToken);
        Task<bool> ChangeStatus(int requestSupportId, Status status, CancellationToken cancellationToken);
        Task<PaginatedList<GetRequestsSupportResult>> GetByStudentId(GetRequestsSupportByStudentIdSpecification specification, CancellationToken cancellationToken);
    }
}
