using EduApoyos.Api.Helpers;
using EduApoyos.Application.Features.Requests.Queries.GetRequests;
using EduApoyos.Domain.Common.Enums;
using MediatR;

namespace EduApoyos.Api.Endpoints
{
    public sealed class RequestSupportsEndpoints : IEndpointsModule
    {
        public void Register(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/requests").WithTags("Requests");

            group.MapGet("/", GetRequests);
        }

        private static async Task<IResult> GetRequests(Status? status, TypeSupport? type, int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetRequestsQuery(status, type, currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);
    }
}
