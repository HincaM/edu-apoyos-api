using EduApoyos.Application.Features.AcademicPrograms.Queries.GetAcademicPrograms;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Api.Extensions
{
    internal static class AcademicProgramsEndpointsDocs
    {
        public static RouteHandlerBuilder WithGetAcademicProgramsDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("GetAcademicPrograms")
                .WithSummary("Lista los programas académicos")
                .WithDescription("Asesor y Estudiante, paginado.")
                .Produces<PaginatedList<AcademicProgramDto>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);
    }
}
