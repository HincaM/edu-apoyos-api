using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Application.Interfaces.Services;
using Mapster;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequestSupportById
{
    public sealed class GetRequestSupportByIdQueryHandler(IRequestSupportService _requestSupportService) : IRequestHandler<GetRequestSupportByIdQuery, ErrorOr<RequestSupportDto>>
    {
        public async Task<ErrorOr<RequestSupportDto>> Handle(GetRequestSupportByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestSupportService.GetRequestSupportById(request.Id, request.UserId, cancellationToken);
            if(result.IsError) return result.Errors;

            if(result.Value is null) return Error.NotFound("Consulta solicitud", "Solicitud no encontrada");

            return result.Value.Adapt<RequestSupportDto>();
        }
    }
}
