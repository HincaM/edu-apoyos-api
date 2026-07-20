using EduApoyos.Api.Extensions;
using EduApoyos.Api.Helpers;
using EduApoyos.Application.Features.Students.Commands.CreateStudent;
using EduApoyos.Application.Features.Students.Queries.GetStudentById;
using EduApoyos.Application.Features.Students.Queries.GetStudents;
using EduApoyos.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EduApoyos.Api.Endpoints
{
    public sealed class StudentsEndpoints : IEndpointsModule
    {
        public void Register(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/students").WithTags("Students");

            group.MapGet("/", GetStudents).RequireAuthorization(new AuthorizeAttribute { Roles = RoleConstants.Advisor }).WithGetStudentsDocs();
            group.MapPost("/", CreateStudent).RequireAuthorization(new AuthorizeAttribute { Roles = RoleConstants.Advisor }).WithCreateStudentDocs();
            group.MapGet("/{id}", GetStudentById).RequireAuthorization(new AuthorizeAttribute { Roles = RoleConstants.Student }).WithGetStudentByIdDocs();
        }

        private static async Task<IResult> GetStudents(int currentPage, int pageSize, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetStudentsQuery(currentPage, pageSize), cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> CreateStudent(CreateStudentCommand command, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(command, cancellationToken)).Match(Results.Ok, Problem);

        private static async Task<IResult> GetStudentById(int id, IMediator sender, CancellationToken cancellationToken)
            => (await sender.Send(new GetStudentByIdQuery(id), cancellationToken)).Match(Results.Ok, Problem);
    }
}
