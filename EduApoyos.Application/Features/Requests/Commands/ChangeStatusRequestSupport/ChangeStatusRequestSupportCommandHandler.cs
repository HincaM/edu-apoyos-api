using EduApoyos.Application.Interfaces.Services;

namespace EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport
{
    public class ChangeStatusRequestSupportCommandHandler(IRequestSupportService _requestSupportService) : IRequestHandler<ChangeStatusRequestSupportCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(ChangeStatusRequestSupportCommand request, CancellationToken cancellationToken) 
            => await _requestSupportService.ChangeStatusRequestSupport(request.RequestSupportId, request.Status, cancellationToken);
    }
}
