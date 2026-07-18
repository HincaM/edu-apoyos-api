using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using Mapster;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequests
{
    public sealed class GetRequestsQueryHandler(IRequestSupportService _requestSupportService) : IRequestHandler<GetRequestsQuery, ErrorOr<PaginatedList<RequestSupportDto>>>
    {
        public async Task<ErrorOr<PaginatedList<RequestSupportDto>>> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestSupportService.GetRequests(request.Adapt<GetRequestsSupportRequest>(), cancellationToken);
            if (result.IsError) return result.Errors;

            return result.Value.Adapt<PaginatedList<RequestSupportDto>>();
        }
    }
}
