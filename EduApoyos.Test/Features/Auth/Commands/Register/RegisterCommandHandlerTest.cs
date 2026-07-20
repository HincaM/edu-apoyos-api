using EduApoyos.Application.Features.Auth.Commands.Register;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using Moq;

namespace EduApoyos.Test.Features.Auth.Commands.Register
{
    public class RegisterCommandHandlerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly RegisterCommandHandler _handler;
        private readonly RegisterCommandValidator _registerValidator = new();
        public RegisterCommandHandlerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _handler = new RegisterCommandHandler(_userServiceMock.Object);
        }

        [Fact]
        public async Task RegisterUserStudentSuccess()
        {
            // Arrange
            var command = new RegisterCommand("123456", DocumentType.Cedula, 1, 1, "UserId", "UsuarioExistente", "test@example.com", "Password123!", Role.Student);
            _userServiceMock
                .Setup(s => s.Register(It.IsAny<RegisterRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Value);
        }

        [Fact]
        public async Task RegisterUserAdvisorSuccess()
        {
            // Arrange
            var command = new RegisterCommand("123456", DocumentType.Cedula, 1, 1, "UserId", "UsuarioExistente", "test@example.com", "Password123!", Role.Advisor);
            _userServiceMock
                .Setup(s => s.Register(It.IsAny<RegisterRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Value);
        }

        [Fact]
        public async Task RegisterUserInvalidaData()
        {
            // Arrange
            var command = new RegisterCommand("123456", DocumentType.Cedula, 1, 1, "UserId", "UsuarioExistente", "", "Password123!", Role.Student);
            _userServiceMock
                .Setup(s => s.Register(It.IsAny<RegisterRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _registerValidator.ValidateAsync(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName.Contains(nameof(command.Email)));
        }
    }
}
