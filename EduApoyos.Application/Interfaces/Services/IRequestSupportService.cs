using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IRequestSupportService
    {
        Task<ErrorOr<bool>> ChangeStatusRequestSupport(int requestSupportId, Status status, CancellationToken cancellationToken);
        Task<ErrorOr<int>> CreateSupport(CreateRequestSupportRequest request, CancellationToken cancellationToken);
        Task<ErrorOr<PaginatedList<RequestSupportDto>>> GetRequests(GetRequestsSupportRequest request, CancellationToken cancellationToken);
        Task<ErrorOr<RequestSupportDto?>> GetRequestSupportById(int id, CancellationToken cancellationToken);
    }
}
