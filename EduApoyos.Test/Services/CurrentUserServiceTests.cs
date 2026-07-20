using EduApoyos.Application.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace EduApoyos.Test.Services;

public class CurrentUserServiceTests
{
    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock = new();

    [Fact]
    public void GetUserIdSuccess()
    {
        // Arrange
        var claims = new List<Claim> { new(ClaimTypes.Name, "1") };
        var identity = new ClaimsIdentity(claims);
        var httpContext = new DefaultHttpContext { User = new ClaimsPrincipal(identity) };
        _httpContextAccessorMock.Setup(a => a.HttpContext).Returns(httpContext);
        var service = new CurrentUserService(_httpContextAccessorMock.Object);

        // Act
        var result = service.UserId;

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetUserIdFailure()
    {
        // Arrange
        _httpContextAccessorMock.Setup(a => a.HttpContext).Returns((HttpContext?)null);
        var service = new CurrentUserService(_httpContextAccessorMock.Object);

        // Act
        var result = service.UserId;

        // Assert
        Assert.Equal(0, result);
    }
}
