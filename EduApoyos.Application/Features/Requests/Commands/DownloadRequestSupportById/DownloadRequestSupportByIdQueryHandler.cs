using EduApoyos.Application.Interfaces.Services;

namespace EduApoyos.Application.Features.Requests.Commands.DownloadRequestSupportById
{
    public sealed class DownloadRequestSupportByIdQueryHandler(IRequestSupportService _requestSupportService) : IRequestHandler<DownloadRequestSupportByIdQuery, ErrorOr<byte[]>>
    {
        public async Task<ErrorOr<byte[]>> Handle(DownloadRequestSupportByIdQuery request, CancellationToken cancellationToken)
        {
            return await _requestSupportService.DownloadFile(request.RequestSupportId, cancellationToken);
        }
    }
}
