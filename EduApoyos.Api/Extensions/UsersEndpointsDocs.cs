using EduApoyos.Application.Features.Users.Queries.GetAdvisors;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Api.Extensions
{
    internal static class UsersEndpointsDocs
    {
        public static RouteHandlerBuilder WithGetUsersDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("GetUsers")
                .WithSummary("Lista los asesores")
                .WithDescription("Asesor, paginado.")
                .Produces<PaginatedList<AdvisorDto>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);
    }
}
