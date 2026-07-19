using EduApoyos.Api.Extensions;
using EduApoyos.Api.Helpers;
using EduApoyos.Application.Features.Users.Queries.GetAdvisors;
using EduApoyos.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EduApoyos.Api.Endpoints
{
    public sealed class UsersEndpoints : IEndpointsModule
    {
        public void Register(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users").WithTags("Users");

            group.MapGet("/", GetAdvisors)
                .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleConstants.Advisor},{RoleConstants.Student}" })
                .WithGetUsersDocs();
        }

        private static async Task<IResult> GetAdvisors(int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetAdvisorsQuery(currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);
    }
}
