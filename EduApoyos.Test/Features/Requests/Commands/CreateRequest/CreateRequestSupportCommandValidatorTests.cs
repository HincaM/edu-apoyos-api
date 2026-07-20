using EduApoyos.Application.Features.Requests.Commands.CreateRequest;
using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Test.Features.Requests.Commands.CreateRequest;

public class CreateRequestSupportCommandValidatorTests
{
    private readonly CreateRequestSupportCommandValidator _validator = new();

    [Fact]
    public async Task CreateRequestSupportCommandValidatorSuccess()
    {
        // Arrange
        var command = new CreateRequestSupportCommand(1, TypeSupport.Loan, 100000, "Ayuda economica", "1");

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public async Task CreateRequestSupportCommandValidatorFailure()
    {
        // Arrange 
        var command = new CreateRequestSupportCommand(1, TypeSupport.Loan, 0, "Ayuda economica", "1");

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.RequestedAmount));
    }
}
