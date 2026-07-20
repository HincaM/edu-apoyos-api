using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Specifications.RequestsSupports;
using Mapster;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequestsSupportByStudentId
{
    public sealed class GetRequestsSupportByStudentIdQueryHandler(IRequestSupportService _requestSupportService) : IRequestHandler<GetRequestsSupportByStudentIdQuery, ErrorOr<PaginatedList<RequestSupportDto>>>
    {
        public async Task<ErrorOr<PaginatedList<RequestSupportDto>>> Handle(GetRequestsSupportByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestSupportService.GetRequestsSupportByStudentId(new GetRequestsSupportByStudentIdSpecification(
                request.StudentId, 
                request.Status,
                request.Type,
                request.CurrentPage, 
                request.PageSize), cancellationToken);
            if (result.IsError) return result.Errors;

            return result.Value.Adapt<PaginatedList<RequestSupportDto>>();
        }
    }
}
