using EduApoyos.Application.Features.Requests.Queries.GetRequestsSupportByStudentId;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Specifications.RequestsSupports;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.Requests.Queries.GetRequestsSupportByStudentId;

public class GetRequestsSupportByStudentIdQueryHandlerTests
{
    private readonly Mock<IRequestSupportService> _requestSupportServiceMock = new();
    private readonly GetRequestsSupportByStudentIdQueryHandler _handler;

    public GetRequestsSupportByStudentIdQueryHandlerTests()
    {
        _handler = new GetRequestsSupportByStudentIdQueryHandler(_requestSupportServiceMock.Object);
    }

    [Fact]
    public async Task GetRequestsSupportByStudentIdSuccess()
    {
        // Arrange
        var query = new GetRequestsSupportByStudentIdQuery(Status.Pending, TypeSupport.Scholarship, 1, 1, 10);
        var paginatedList = new PaginatedList<GetRequestsSupportResult>
        {
            CurrentPage = 1,
            PageSize = 10,
            TotalCount = 1,
            Results =
            [
                new GetRequestsSupportResult
                {
                    Id = 1,
                    StudentId = 1,
                    StudentName = "Estudiante Test",
                    TypeSupport = TypeSupport.Scholarship,
                    RequestedAmount = 100000,
                    Description = "Ayuda economica",
                    Status = Status.Pending,
                    ApplicationDate = DateTime.UtcNow,
                    AdvisorId = 1,
                    AdvisorName = "Asesor Test"
                }
            ]
        };
        _requestSupportServiceMock
            .Setup(s => s.GetRequestsSupportByStudentId(It.IsAny<GetRequestsSupportByStudentIdSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(paginatedList);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Single(result.Value.Results);
    }

    [Fact]
    public async Task GetRequestsSupportByStudentIdFailure()
    {
        // Arrange
        var query = new GetRequestsSupportByStudentIdQuery(Status.Pending, TypeSupport.Scholarship, 1, 1, 10);
        _requestSupportServiceMock
            .Setup(s => s.GetRequestsSupportByStudentId(It.IsAny<GetRequestsSupportByStudentIdSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.Failure("RequestsSupport.Error", "Error al obtener solicitudes del estudiante"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.Failure, result.FirstError.Type);
    }

    [Fact]
    public async Task GetRequestsSupportByStudentIdValidationFailure()
    {
        // Arrange
        var query = new GetRequestsSupportByStudentIdQuery(Status.Pending, TypeSupport.Scholarship, 1, 1, 10);
        _requestSupportServiceMock
            .Setup(s => s.GetRequestsSupportByStudentId(It.IsAny<GetRequestsSupportByStudentIdSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.NotFound("Get requests support by student id", "Error"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
    }
}
