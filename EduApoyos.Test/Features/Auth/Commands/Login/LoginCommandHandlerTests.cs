using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Features.Auth.Commands.Login;
using EduApoyos.Application.Helpers;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Models;
using Microsoft.Extensions.Configuration;
using Moq;

namespace EduApoyos.Test.Features.Auth.Commands.Login;

public class LoginCommandHandlerTests
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly TokenGeneratorHelper _tokenGeneratorHelper;
    private readonly LoginCommandHandler _handler;
    private readonly string User = "userId";

    public LoginCommandHandlerTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Jwt:Key"] = "clavesecretaparapruebasunitarias",
                ["Jwt:Issuer"] = "EduApoyosTest",
                ["Jwt:Audience"] = "EduApoyosTest"
            })
            .Build();

        _tokenGeneratorHelper = new TokenGeneratorHelper(configuration);
        _handler = new LoginCommandHandler(_userServiceMock.Object, _tokenGeneratorHelper);
    }

    [Fact]
    public async Task UserDoesNotExist()
    {
        _userServiceMock
            .Setup(s => s.GetUserById("NoExiste", It.IsAny<CancellationToken>()))
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
        var user = new GetUserResult(User, "user1@test.com", Role.Student, passwordHash);

        _userServiceMock
            .Setup(s => s.GetUserById("User", It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var result = await _handler.Handle(new LoginCommand(User, claveIncorrecta), CancellationToken.None);

        Assert.True(result.IsError);
        Assert.Equal(ErrorOr.ErrorType.Unauthorized, result.FirstError.Type);
    }

    [Fact]
    public async Task UserAuthorized()
    {
        string claveCorrecta = "claveCorrecta";
        var passwordHash = new PasswordHashHelper().Hash(claveCorrecta);
        var user = new GetUserResult(User, "user1@test.com", Role.Student, passwordHash);

        _userServiceMock
            .Setup(s => s.GetUserById(User, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var result = await _handler.Handle(new LoginCommand(User, claveCorrecta), CancellationToken.None);

        Assert.False(result.IsError);
        Assert.False(string.IsNullOrWhiteSpace(result.Value));
    }
}
