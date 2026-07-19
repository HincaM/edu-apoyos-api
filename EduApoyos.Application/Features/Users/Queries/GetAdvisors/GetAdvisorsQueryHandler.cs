using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using Mapster;

namespace EduApoyos.Application.Features.Users.Queries.GetAdvisors
{
    public sealed class GetAdvisorsQueryHandler(IUserService _userService) : IRequestHandler<GetAdvisorsQuery, ErrorOr<PaginatedList<AdvisorDto>>>
    {
        public async Task<ErrorOr<PaginatedList<AdvisorDto>>> Handle(GetAdvisorsQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetAdvisors(request.Adapt<GetAdvisorRequest>(), cancellationToken);

            if (result.IsError) return result.Errors;

            return result.Value.Adapt<PaginatedList<AdvisorDto>>();
        }
    }
}
