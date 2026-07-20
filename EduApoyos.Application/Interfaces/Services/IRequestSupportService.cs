using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Specifications.RequestsSupports;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IRequestSupportService
    {
        Task<ErrorOr<bool>> ChangeStatusRequestSupport(ChangeStatusRequestSupportRequest request, CancellationToken cancellationToken);
        Task<ErrorOr<int>> CreateSupport(CreateRequestSupportRequest request, CancellationToken cancellationToken);
        Task<ErrorOr<PaginatedList<GetRequestsSupportResult>>> GetRequests(GetRequestsSupportRequest request, CancellationToken cancellationToken);
        Task<ErrorOr<PaginatedList<GetRequestsSupportResult>>> GetRequestsSupportByStudentId(GetRequestsSupportByStudentIdSpecification specification, CancellationToken cancellationToken);
        Task<ErrorOr<GetRequestsSupportResult?>> GetRequestSupportById(int id, string? email, CancellationToken cancellationToken);
    }
}
