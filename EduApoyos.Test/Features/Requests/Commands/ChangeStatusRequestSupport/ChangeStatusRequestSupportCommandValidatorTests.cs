using EduApoyos.Application.Features.Requests.Commands.ChangeStatusRequestSupport;
using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Test.Features.Requests.Commands.ChangeStatusRequestSupport;

public class ChangeStatusRequestSupportCommandValidatorTests
{
    private readonly ChangeStatusRequestSupportCommandValidator _validator = new();

    [Fact]
    public async Task ChangeStatusRequestSupportCommandValidatorSuccess()
    {
        // Arrange
        var command = new ChangeStatusRequestSupportCommand(1, Status.UnderReview, Status.Approved, "Aprobada");

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public async Task ChangeStatusRequestSupportCommandValidatorFailure()
    {
        // Arrange
        var command = new ChangeStatusRequestSupportCommand(1, Status.Approved, Status.Approved, "Sin cambios");

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.CurrentStatus));
    }
}
