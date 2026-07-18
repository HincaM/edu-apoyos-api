using EduApoyos.Application.Features.Requests.Queries.GetRequests;
using EduApoyos.Domain.Models;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications;
using Mapster;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class RequestSupportService(IRequestSupportRepository _requestSupportRepository) : IRequestSupportService
    {
        public async Task<ErrorOr<PaginatedList<RequestSupportDto>>> GetRequests(GetRequestsSupportRequest request, CancellationToken cancellationToken)
        {
            return (await _requestSupportRepository.GetRequests(new GetRequestSupportSpecification(
                request.Status,
                request.Type,
                request.CurrentPage,
                request.PageSize
            ), cancellationToken)).Adapt<PaginatedList<RequestSupportDto>>();
        }
    }
}
