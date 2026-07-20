using EduApoyos.Application.Features.Students.Commands.CreateStudent;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using Moq;

namespace EduApoyos.Test.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandHandlerTests
{
    private readonly Mock<IStudentsService> _studentsServiceMock = new();
    private readonly CreateStudentCommandHandler _handler;

    public CreateStudentCommandHandlerTests()
    {
        _handler = new CreateStudentCommandHandler(_studentsServiceMock.Object);
    }

    [Fact]
    public async Task CreateStudentSuccess()
    {
        // Arrange
        var command = new CreateStudentCommand("1", "123456", DocumentType.Cedula, 1, 3);
        _studentsServiceMock
            .Setup(s => s.CreateStudent(It.IsAny<CreateStudentRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Equal(1, result.Value);
    }

    [Fact]
    public async Task CreateStudentFailure()
    {
        // Arrange
        var command = new CreateStudentCommand("1", "123456", DocumentType.Cedula, 1, 3);
        _studentsServiceMock
            .Setup(s => s.CreateStudent(It.IsAny<CreateStudentRequest>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Error al crear estudiante"));

        // Act
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Assert
        await Assert.ThrowsAsync<Exception>(act);
    }
}
