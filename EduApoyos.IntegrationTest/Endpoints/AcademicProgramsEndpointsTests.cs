using System.Net;

namespace EduApoyos.IntegrationTest.Endpoints;

public class AcademicProgramsEndpointsTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public AcademicProgramsEndpointsTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAcademicPrograms()
    {
        // Arrange
        var url = "api/academic-programs?currentPage=1&pageSize=10";

        // Act
        var response = await _client.GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
