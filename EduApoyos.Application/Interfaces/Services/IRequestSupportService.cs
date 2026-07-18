using EduApoyos.Application.Features.Requests.Queries.GetRequests;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;

namespace EduApoyos.Application.Interfaces.Services
{
    public interface IRequestSupportService
    {
        Task<ErrorOr<PaginatedList<RequestSupportDto>>> GetRequests(GetRequestsSupportRequest request, CancellationToken cancellationToken);
    }
}
