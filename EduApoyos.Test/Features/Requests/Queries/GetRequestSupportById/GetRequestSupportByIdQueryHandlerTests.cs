using EduApoyos.Application.Features.Requests.Queries.GetRequestSupportById;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.Requests.Queries.GetRequestSupportById;

public class GetRequestSupportByIdQueryHandlerTests
{
    private readonly Mock<IRequestSupportService> _requestSupportServiceMock = new();
    private readonly GetRequestSupportByIdQueryHandler _handler;

    public GetRequestSupportByIdQueryHandlerTests()
    {
        _handler = new GetRequestSupportByIdQueryHandler(_requestSupportServiceMock.Object);
    }

    [Fact]
    public async Task GetRequestSupportByIdSuccess()
    {
        // Arrange
        var query = new GetRequestSupportByIdQuery(1);
        var requestSupport = new GetRequestsSupportResult
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
        };
        _requestSupportServiceMock
            .Setup(s => s.GetRequestSupportById(query.Id, query.email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(requestSupport);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Equal(requestSupport.Id, result.Value.Id);
    }

    [Fact]
    public async Task GetRequestSupportByIdFailure()
    {
        // Arrange
        var query = new GetRequestSupportByIdQuery(1);
        _requestSupportServiceMock
            .Setup(s => s.GetRequestSupportById(query.Id, query.email, It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetRequestsSupportResult?)null);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
    }

    [Fact]
    public async Task GetRequestSupportByIdValidationFailure()
    {
        // Arrange
        var query = new GetRequestSupportByIdQuery(1);
        _requestSupportServiceMock
            .Setup(s => s.GetRequestSupportById(query.Id, query.email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.NotFound("Get request support", "Error"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
    }
}
