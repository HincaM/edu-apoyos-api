using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Models;
using Mapster;

namespace EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport
{
    public class ChangeStatusRequestSupportCommandHandler(IRequestSupportService _requestSupportService) : IRequestHandler<ChangeStatusRequestSupportCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(ChangeStatusRequestSupportCommand request, CancellationToken cancellationToken) 
            => await _requestSupportService.ChangeStatusRequestSupport(request.Adapt<ChangeStatusRequestSupportRequest>(), cancellationToken);
    }
}
