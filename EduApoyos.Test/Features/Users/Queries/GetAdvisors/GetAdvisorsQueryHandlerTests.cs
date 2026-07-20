using EduApoyos.Application.Features.Users.Queries.GetAdvisors;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.Users.Queries.GetAdvisors;

public class GetAdvisorsQueryHandlerTests
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly GetAdvisorsQueryHandler _handler;

    public GetAdvisorsQueryHandlerTests()
    {
        _handler = new GetAdvisorsQueryHandler(_userServiceMock.Object);
    }

    [Fact]
    public async Task GetAdvisorsSuccess()
    {
        // Arrange
        var query = new GetAdvisorsQuery(1, 10);
        var paginatedList = new PaginatedList<GetAdvisorResult>
        {
            CurrentPage = 1,
            PageSize = 10,
            TotalCount = 1,
            Results = [new GetAdvisorResult(1, "Asesor Test")]
        };
        _userServiceMock
            .Setup(s => s.GetAdvisors(It.IsAny<GetAdvisorRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(paginatedList);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Single(result.Value.Results);
    }

    [Fact]
    public async Task GetAdvisorsFailure()
    {
        // Arrange
        var query = new GetAdvisorsQuery(1, 10);
        _userServiceMock
            .Setup(s => s.GetAdvisors(It.IsAny<GetAdvisorRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.Failure("Advisors.Error", "Error al obtener asesores"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.Failure, result.FirstError.Type);
    }
}
