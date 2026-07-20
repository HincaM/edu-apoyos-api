using EduApoyos.Application.Features.Students.Queries.GetStudentById;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.Students.Queries.GetStudentById;

public class GetStudentByIdQueryHandlerTests
{
    private readonly Mock<IStudentsService> _studentsServiceMock = new();
    private readonly GetStudentByIdQueryHandler _handler;

    public GetStudentByIdQueryHandlerTests()
    {
        _handler = new GetStudentByIdQueryHandler(_studentsServiceMock.Object);
    }

    [Fact]
    public async Task GetStudentByIdSuccess()
    {
        // Arrange
        var query = new GetStudentByIdQuery(1);
        var student = new GetStudentResult(1, 1, "Usuario Test", "123456", DocumentType.Cedula, 1, "Sistemas", 3);
        _studentsServiceMock
            .Setup(s => s.GetStudentById(query.StudentId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(student);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Equal(student.Id, result.Value.Id);
    }

    [Fact]
    public async Task GetStudentByIdFailure()
    {
        // Arrange
        var query = new GetStudentByIdQuery(1);
        _studentsServiceMock
            .Setup(s => s.GetStudentById(query.StudentId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetStudentResult?)null);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
    }

    [Fact]
    public async Task GetStudentByIdValidationFailure()
    {
        // Arrange
        var query = new GetStudentByIdQuery(1);
        _studentsServiceMock
            .Setup(s => s.GetStudentById(query.StudentId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.NotFound("Get students","Error"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
    }
}
