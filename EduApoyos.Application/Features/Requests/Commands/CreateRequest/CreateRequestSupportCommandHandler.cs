using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Models;
using Mapster;

namespace EduApoyos.Application.Features.Requests.Commands.CreateRequest
{
    public sealed class CreateRequestSupportCommandHandler(IRequestSupportService _requestSupportService) : IRequestHandler<CreateRequestSupportCommand, ErrorOr<int>>
    {
        public async Task<ErrorOr<int>> Handle(CreateRequestSupportCommand request, CancellationToken cancellationToken) 
            => await _requestSupportService.CreateSupport(request.Adapt<CreateRequestSupportRequest>(), cancellationToken);
    }
}
