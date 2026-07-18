using EduApoyos.Api.Helpers;
using EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport;
using EduApoyos.Application.Features.Requests.Commands.CreateRequest;
using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupport;
using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupportByStudentId;
using EduApoyos.Application.Features.Requests.Queries.GetRequestSupportById;
using EduApoyos.Domain.Common.Enums;
using MediatR;

namespace EduApoyos.Api.Endpoints
{
    public sealed class RequestSupportsEndpoints : IEndpointsModule
    {
        public void Register(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/requests").WithTags("RequestsSupport");

            group.MapGet("/", GetRequestsSupport);
            group.MapPost("/", CreateRequestSupport);
            group.MapGet("/{id}", GetRequestSupportById);
            group.MapPatch("/{id}/estado", ChangeStatusRequestSupport);

            app.MapGet("api/students/{id}/requests", GetRequestsSupportByStudentId).WithTags("RequestsSupport");
        }

        private static async Task<IResult> GetRequestsSupport(Status? status, TypeSupport? type, int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetRequestsSupportQuery(status, type, currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> CreateRequestSupport(CreateRequestSupportCommand command, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(command, cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> GetRequestSupportById(int id, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetRequestSupportByIdQuery(id), cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> ChangeStatusRequestSupport(int id, ChangeStatusRequestSupportCommand command, IMediator sender, CancellationToken cancellationToken)
        {
            var commandSend = command with { RequestSupportId = id };
            return (await sender.Send(commandSend, cancellationToken)).Match(Results.Ok, Problem);
        }

        private static async Task<IResult> GetRequestsSupportByStudentId(int id, int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetRequestsSupportByStudentIdQuery(id, currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);
        
    }
}
