using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace EduApoyos.IntegrationTest.Endpoints;

public class StudentsEndpointsTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public StudentsEndpointsTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetStudents()
    {
        // Arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _factory.GenerateAdvisorToken());

        // Act
        var response = await client.GetAsync("api/students?currentPage=1&pageSize=10");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateStudent()
    {
        // Arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _factory.GenerateAdvisorToken());
        var body = new
        {
            UserId = "1",
            DocumentNumber = "112233",
            DocumentType = 1,
            AcademicProgramId = CustomWebApplicationFactory.AcademicProgramId,
            Semester = 1
        };

        // Act
        var response = await client.PostAsJsonAsync("api/students", body);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetStudentById()
    {
        // Arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _factory.GenerateStudentToken());

        // Act
        var response = await client.GetAsync($"api/students/{CustomWebApplicationFactory.StudentId}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
