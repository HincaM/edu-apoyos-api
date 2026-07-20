using EduApoyos.Api.Extensions;
using EduApoyos.Api.Helpers;
using EduApoyos.Application.Features.AcademicPrograms.Queries.GetAcademicPrograms;
using EduApoyos.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EduApoyos.Api.Endpoints
{
    public sealed class AcademicProgramsEndpoints : IEndpointsModule
    {
        public void Register(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/academic-programs").WithTags("AcademicPrograms");

            group.MapGet("/", GetAcademicPrograms)
                .AllowAnonymous()
                .WithGetAcademicProgramsDocs();
        }

        private static async Task<IResult> GetAcademicPrograms(int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetAcademicProgramsQuery(currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);
    }
}
