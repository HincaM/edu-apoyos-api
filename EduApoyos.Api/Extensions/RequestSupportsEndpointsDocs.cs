using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Domain.Common.Helpers;

namespace EduApoyos.Api.Endpoints
{
    internal static class RequestSupportsEndpointsDocs
    {
        public static RouteHandlerBuilder WithGetAllDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("GetRequestsSupport")
                .WithSummary("Lista las solicitudes de apoyo")
                .WithDescription("Solo Asesor. Permite filtrar por estado y tipo, con paginacion.")
                .Produces<PaginatedList<RequestSupportDto>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);

        public static RouteHandlerBuilder WithCreateDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("CreateRequestSupport")
                .WithSummary("Crea una solicitud de apoyo")
                .WithDescription("Asesor o Estudiante.")
                .Produces<int>(StatusCodes.Status200OK)
                .ProducesValidationProblem()
                .ProducesProblem(StatusCodes.Status401Unauthorized);

        public static RouteHandlerBuilder WithGetByIdDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("GetRequestSupportById")
                .WithSummary("Obtiene una solicitud de apoyo por Id")
                .WithDescription("Asesor puede consultar cualquier solicitud. Estudiante solo puede consultar sus propias solicitudes.")
                .Produces<RequestSupportDto>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);

        public static RouteHandlerBuilder WithChangeStatusDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("ChangeStatusRequestSupport")
                .WithSummary("Cambia el estado de una solicitud de apoyo")
                .WithDescription("Solo Asesor.")
                .Produces<bool>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);

        public static RouteHandlerBuilder WithGetByStudentIdDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("GetRequestsSupportByStudentId")
                .WithSummary("Lista las solicitudes de apoyo de un estudiante")
                .WithDescription("Solo Estudiante, paginado.")
                .Produces<PaginatedList<RequestSupportDto>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);

        public static RouteHandlerBuilder DownloadRequestSupportByIdDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("DownloadRequestSupportById")
                .WithSummary("Descarga la constancia en PDF de una solicitud de apoyo")
                .WithDescription("Asesor puede descargar cualquier solicitud. Estudiante solo puede descargar sus propias solicitudes.")
                .Produces<string>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesProblem(StatusCodes.Status401Unauthorized)
                .ProducesProblem(StatusCodes.Status403Forbidden);
    }
}
