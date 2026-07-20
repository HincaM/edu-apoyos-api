using EduApoyos.Application.Features.Requests.Commands.CreateRequest;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.Requests.Commands.CreateRequest;

public class CreateRequestSupportCommandHandlerTests
{
    private readonly Mock<IRequestSupportService> _requestSupportServiceMock = new();
    private readonly CreateRequestSupportCommandHandler _handler;

    public CreateRequestSupportCommandHandlerTests()
    {
        _handler = new CreateRequestSupportCommandHandler(_requestSupportServiceMock.Object);
    }

    [Fact]
    public async Task CreateRequestSupportSuccess()
    {
        // Arrange
        var command = new CreateRequestSupportCommand(1, TypeSupport.Scholarship, 100000, "Ayuda economica", "1");
        _requestSupportServiceMock
            .Setup(s => s.CreateSupport(It.IsAny<CreateRequestSupportRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Equal(1, result.Value);
    }

    [Fact]
    public async Task CreateRequestSupportFailure()
    {
        // Arrange
        var command = new CreateRequestSupportCommand(1, TypeSupport.Scholarship, 100000, "Ayuda economica", "1");
        _requestSupportServiceMock
            .Setup(s => s.CreateSupport(It.IsAny<CreateRequestSupportRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.Failure("RequestSupport.Error", "Error al crear la solicitud"));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.Failure, result.FirstError.Type);
    }
}
