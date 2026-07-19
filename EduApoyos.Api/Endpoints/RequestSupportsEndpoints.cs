using EduApoyos.Api.Helpers;
using EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport;
using EduApoyos.Application.Features.Requests.Commands.CreateRequest;
using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupportByStudentId;
using EduApoyos.Application.Features.Requests.Queries.GetRequestSupportById;
using EduApoyos.Domain.Common;
using EduApoyos.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EduApoyos.Api.Endpoints
{
    public sealed class RequestSupportsEndpoints : IEndpointsModule
    {
        public void Register(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/requests").WithTags("RequestsSupport");

            group.MapGet("/", GetRequestsSupport)
                .RequireAuthorization(new AuthorizeAttribute { Roles = RoleConstants.Advisor })
                .WithGetAllDocs();
            group.MapPost("/", CreateRequestSupport)
                .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleConstants.Advisor},{RoleConstants.Student}" })
                .WithCreateDocs();
            group.MapGet("/{id}", GetRequestSupportById)
                .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleConstants.Advisor},{RoleConstants.Student}" })
                .WithGetByIdDocs();
            group.MapPatch("/{id}/estado", ChangeStatusRequestSupport)
                .RequireAuthorization(RoleConstants.Advisor)
                .WithChangeStatusDocs();

            app.MapGet("api/students/{id}/requests", GetRequestsSupportByStudentId)
                .WithTags("RequestsSupport")
                .RequireAuthorization(RoleConstants.Student)
                .WithGetByStudentIdDocs();
        }

        private static async Task<IResult> GetRequestsSupport(Status? status, TypeSupport? type, int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetRequestsSupportQuery(status, type, currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> CreateRequestSupport(CreateRequestSupportCommand command, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(command, cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> GetRequestSupportById(int id, IMediator sender, CancellationToken cancellationToken, ClaimsPrincipal user)
        {
            var userId = user.IsInRole("Estudiante") ? user.FindFirst(ClaimTypes.NameIdentifier)?.Value : null;
            return (await sender.Send(new GetRequestSupportByIdQuery(id, userId), cancellationToken)).Match(Results.Ok, Problem);
        }

        private static async Task<IResult> ChangeStatusRequestSupport(int id, ChangeStatusRequestSupportCommand command, IMediator sender, CancellationToken cancellationToken)
        {
            var commandSend = command with { RequestSupportId = id };
            return (await sender.Send(commandSend, cancellationToken)).Match(Results.Ok, Problem);
        }

        private static async Task<IResult> GetRequestsSupportByStudentId(int id, int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetRequestsSupportByStudentIdQuery(id, currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);
        
    }
}
