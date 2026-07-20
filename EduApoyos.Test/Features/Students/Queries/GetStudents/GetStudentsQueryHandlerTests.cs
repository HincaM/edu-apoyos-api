using EduApoyos.Application.Features.Students.Queries.GetStudents;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.Students.Queries.GetStudents;

public class GetStudentsQueryHandlerTests
{
    private readonly Mock<IStudentsService> _studentsServiceMock = new();
    private readonly GetStudentsQueryHandler _handler;

    public GetStudentsQueryHandlerTests()
    {
        _handler = new GetStudentsQueryHandler(_studentsServiceMock.Object);
    }

    [Fact]
    public async Task GetStudentsSuccess()
    {
        // Arrange
        var query = new GetStudentsQuery(1, 10);
        var paginatedList = new PaginatedList<GetStudentResult>
        {
            CurrentPage = 1,
            PageSize = 10,
            TotalCount = 1,
            Results = [new GetStudentResult(1, 1, "Usuario Test", "123456", DocumentType.Cedula, 1, "Sistemas", 3)]
        };
        _studentsServiceMock
            .Setup(s => s.GetStudents(It.IsAny<GetStudentRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(paginatedList);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Single(result.Value.Results);
    }

    [Fact]
    public async Task GetStudentsFailure()
    {
        // Arrange
        var query = new GetStudentsQuery(1, 10);
        _studentsServiceMock
            .Setup(s => s.GetStudents(It.IsAny<GetStudentRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.Failure("Students.Error", "Error al obtener estudiantes"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.Failure, result.FirstError.Type);
    }

    [Fact]
    public async Task GetStudentsValidationFailure()
    {
        // Arrange
        var query = new GetStudentsQuery(1, 10);
        _studentsServiceMock
            .Setup(s => s.GetStudents(It.IsAny<GetStudentRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.NotFound("Get students", "Error"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
    }
}
