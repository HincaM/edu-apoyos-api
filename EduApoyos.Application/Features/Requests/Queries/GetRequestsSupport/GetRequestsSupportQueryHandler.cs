using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using Mapster;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport
{
    public sealed class GetRequestsSupportQueryHandler(IRequestSupportService _requestSupportService) : IRequestHandler<GetRequestsSupportQuery, ErrorOr<PaginatedList<RequestSupportDto>>>
    {
        public async Task<ErrorOr<PaginatedList<RequestSupportDto>>> Handle(GetRequestsSupportQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestSupportService.GetRequests(request.Adapt<GetRequestsSupportRequest>(), cancellationToken);
            if (result.IsError) return result.Errors;

            return result.Value.Adapt<PaginatedList<RequestSupportDto>>();
        }
    }
}
