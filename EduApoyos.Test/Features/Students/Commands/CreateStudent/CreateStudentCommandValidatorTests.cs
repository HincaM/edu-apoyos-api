using EduApoyos.Application.Features.Students.Commands.CreateStudent;
using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Test.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandValidatorTests
{
    private readonly CreateStudentCommandValidator _validator = new();

    [Fact]
    public async Task CreateStudentCommandValidatorSuccess()
    {
        // Arrange
        var command = new CreateStudentCommand("1", "123456", DocumentType.Cedula, 1, 3);

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public async Task CreateStudentCommandValidatorFailure()
    {
        // Arrange
        var command = new CreateStudentCommand("1", "", DocumentType.Cedula, 1, 3);

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.DocumentNumber));
    }
}
