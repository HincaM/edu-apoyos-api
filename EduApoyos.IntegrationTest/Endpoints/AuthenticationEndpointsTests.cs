using System.Net;
using System.Net.Http.Json;

namespace EduApoyos.IntegrationTest.Endpoints;

public class AuthenticationEndpointsTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public AuthenticationEndpointsTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login()
    {
        // Arrange
        var body = new { Email = CustomWebApplicationFactory.StudentEmail, Password = "Password123!" };

        // Act
        var response = await _client.PostAsJsonAsync("api/auth/login", body);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Register()
    {
        // Arrange
        var body = new
        {
            DocumentNumber = "987654",
            DocumentType = 1,
            AcademicProgramId = CustomWebApplicationFactory.AcademicProgramId,
            Semester = 2,
            FullName = "Nuevo Estudiante",
            Email = "nuevo.estudiante@test.com",
            Password = "Password123!",
            Role = 2
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/auth/register", body);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
