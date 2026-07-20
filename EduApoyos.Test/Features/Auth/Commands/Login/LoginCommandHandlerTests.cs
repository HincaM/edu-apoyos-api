using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Features.Auth.Commands.Login;
using EduApoyos.Application.Helpers;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace EduApoyos.Test.Features.Auth.Commands.Login;

public class LoginCommandHandlerTests
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<IStudentsService> _studentServiceMock = new();
    private readonly Mock<IOptions<TokenOption>> _options = new();
    private readonly TokenGeneratorHelper _tokenGeneratorHelper;
    private readonly LoginCommandHandler _handler;
    private readonly string Email = "user1@test.com";

    public LoginCommandHandlerTests()
    {
        _options.Setup(o => o.Value).Returns(new TokenOption { ExpireMinutes = 60, Issuer = "issuer", Audience = "audience", Key = "supersecretkey12345678901234567890" });
        _tokenGeneratorHelper = new TokenGeneratorHelper(_options.Object);
        _handler = new LoginCommandHandler(_userServiceMock.Object, _studentServiceMock.Object, _tokenGeneratorHelper);
    }

    [Fact]
    public async Task UserDoesNotExist()
    {
        _userServiceMock
            .Setup(s => s.GetUserByEmail("NoExiste", It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetUserResult?)null);

        var result = await _handler.Handle(new LoginCommand("NoExiste", "cualquier-clave"), CancellationToken.None);

        Assert.True(result.IsError);
        Assert.Equal(ErrorOr.ErrorType.Unauthorized, result.FirstError.Type);
    }

    [Fact]
    public async Task UserUnauthorized()
    {
        string claveCorrecta = "claveCorrecta";
        string claveIncorrecta = "claveIncorrecta";
        var passwordHash = new PasswordHashHelper().Hash(claveCorrecta);
        var user = new GetUserResult(1, Email, Role.Student, passwordHash);

        _userServiceMock
            .Setup(s => s.GetUserByEmail(Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var result = await _handler.Handle(new LoginCommand(Email, claveIncorrecta), CancellationToken.None);

        Assert.True(result.IsError);
        Assert.Equal(ErrorOr.ErrorType.Unauthorized, result.FirstError.Type);
    }

    [Fact]
    public async Task UserAuthorized()
    {
        string claveCorrecta = "claveCorrecta";
        var passwordHash = new PasswordHashHelper().Hash(claveCorrecta);
        var user = new GetUserResult(1, Email, Role.Student, passwordHash);

        _userServiceMock
            .Setup(s => s.GetUserByEmail(Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var result = await _handler.Handle(new LoginCommand(Email, claveCorrecta), CancellationToken.None);

        Assert.False(result.IsError);
        Assert.False(string.IsNullOrWhiteSpace(result.Value));
    }
}
