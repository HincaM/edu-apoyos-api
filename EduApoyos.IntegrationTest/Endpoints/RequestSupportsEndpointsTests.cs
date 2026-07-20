using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace EduApoyos.IntegrationTest.Endpoints;

public class RequestSupportsEndpointsTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public RequestSupportsEndpointsTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetRequestsSupport()
    {
        // Arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _factory.GenerateAdvisorToken());

        // Act
        var response = await client.GetAsync("api/requests?currentPage=1&pageSize=10");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateRequestSupport()
    {
        // Arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _factory.GenerateStudentToken());
        var body = new
        {
            StudentId = CustomWebApplicationFactory.StudentId,
            TypeSupport = 1,
            RequestedAmount = 50000,
            Description = "Ayuda para matricula",
            AdvisorId = "2"
        };

        // Act
        var response = await client.PostAsJsonAsync("api/requests", body);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetRequestSupportById()
    {
        // Arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _factory.GenerateAdvisorToken());

        // Act
        var response = await client.GetAsync($"api/requests/{CustomWebApplicationFactory.RequestSupportId}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetRequestsSupportByStudentId()
    {
        // Arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _factory.GenerateStudentToken());

        // Act
        var response = await client.GetAsync($"api/students/{CustomWebApplicationFactory.StudentId}/requests?currentPage=1&pageSize=10");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
