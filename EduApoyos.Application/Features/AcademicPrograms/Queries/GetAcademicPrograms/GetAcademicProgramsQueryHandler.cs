using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using Mapster;

namespace EduApoyos.Application.Features.AcademicPrograms.Queries.GetAcademicPrograms
{
    public sealed class GetAcademicProgramsQueryHandler(IAcademicProgramService _academicProgramService) : IRequestHandler<GetAcademicProgramsQuery, ErrorOr<PaginatedList<AcademicProgramDto>>>
    {
        public async Task<ErrorOr<PaginatedList<AcademicProgramDto>>> Handle(GetAcademicProgramsQuery request, CancellationToken cancellationToken)
        {
            var result = await _academicProgramService.GetAcademicPrograms(request.Adapt<GetAcademicProgramRequest>(), cancellationToken);

            if (result.IsError) return result.Errors;

            return result.Value.Adapt<PaginatedList<AcademicProgramDto>>();
        }
    }
}
