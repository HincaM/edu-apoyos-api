using EduApoyos.Application.Features.Auth.Commands.Register;
using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Test.Features.Auth.Commands.Register
{
    public class RegisterCommandValidatorTests
    {
        private readonly RegisterCommandValidator _validator = new();

        [Fact]
        public async Task RegisterCommandVaidatorSuccess()
        {
            // Arrange
            var command = new RegisterCommand("123456", DocumentType.Cedula, 1, 1, "Angel Arenas", "aarenas@eduapoyos.com", "claveusuario", Role.Advisor);

            // Act
            var result = await _validator.ValidateAsync(command);

            // Assert
            Assert.True(result.IsValid);

        }

        [Fact]
        public async Task RegisterCommandVaidatorFailure()
        {
            // Arrange
            var command = new RegisterCommand("123456", DocumentType.Cedula, 1, 1, "", "aarenas@eduapoyos.com", "claveusuario", Role.Advisor);

            // Act
            var result = await _validator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(command.FullName));

        }
    }
}
