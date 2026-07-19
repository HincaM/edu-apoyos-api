using EduApoyos.Application.Features.Students.Queries.GetStudents;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Api.Extensions
{
    internal static class StudentsEndpointsDocs
    {
        public static RouteHandlerBuilder WithGetStudentsDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("GetStudents")
                .WithSummary("Lista los estudiantes")
                .WithDescription("Solo Asesor, paginado.")
                .Produces<PaginatedList<StudentDto>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);

        public static RouteHandlerBuilder WithCreateStudentDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("CreateStudent")
                .WithSummary("Crea un estudiante")
                .WithDescription("Solo Asesor.")
                .Produces<int>(StatusCodes.Status200OK)
                .ProducesValidationProblem()
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);
    }
}
