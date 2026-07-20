using EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.Requests.Commands.ChangeStatusRequestSupport;

public class ChangeStatusRequestSupportCommandHandlerTests
{
    private readonly Mock<IRequestSupportService> _requestSupportServiceMock = new();
    private readonly ChangeStatusRequestSupportCommandHandler _handler;

    public ChangeStatusRequestSupportCommandHandlerTests()
    {
        _handler = new ChangeStatusRequestSupportCommandHandler(_requestSupportServiceMock.Object);
    }

    [Fact]
    public async Task ChangeStatusRequestSupportSuccess()
    {
        // Arrange 
        var command = new ChangeStatusRequestSupportCommand(1, Status.Pending, Status.Approved, "Aprobada");
        _requestSupportServiceMock
            .Setup(s => s.ChangeStatusRequestSupport(It.IsAny<ChangeStatusRequestSupportRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.True(result.Value);
    }

    [Fact]
    public async Task ChangeStatusRequestSupportFailure()
    {
        // Arrange
        var command = new ChangeStatusRequestSupportCommand(1, Status.Pending, Status.Approved, "Aprobada");
        _requestSupportServiceMock
            .Setup(s => s.ChangeStatusRequestSupport(It.IsAny<ChangeStatusRequestSupportRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.Failure("RequestSupport.Error", "Error al cambiar el estado de la solicitud"));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.Failure, result.FirstError.Type);
    }
}
