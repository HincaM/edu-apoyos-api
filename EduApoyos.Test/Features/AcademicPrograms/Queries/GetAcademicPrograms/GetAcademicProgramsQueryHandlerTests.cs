using EduApoyos.Application.Features.AcademicPrograms.Queries.GetAcademicPrograms;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using ErrorOr;
using Moq;

namespace EduApoyos.Test.Features.AcademicPrograms.Queries.GetAcademicPrograms;

public class GetAcademicProgramsQueryHandlerTests
{
    private readonly Mock<IAcademicProgramService> _academicProgramServiceMock = new();
    private readonly GetAcademicProgramsQueryHandler _handler;

    public GetAcademicProgramsQueryHandlerTests()
    {
        _handler = new GetAcademicProgramsQueryHandler(_academicProgramServiceMock.Object);
    }

    [Fact]
    public async Task GetAcademicProgramsSuccess()
    {
        // Arrange
        var query = new GetAcademicProgramsQuery(1, 10);
        var paginatedList = new PaginatedList<GetAcademicProgramResult>
        {
            CurrentPage = 1,
            PageSize = 10,
            TotalCount = 1,
            Results = [new GetAcademicProgramResult(1, "Sistemas", "Ingenieria de Sistemas")]
        };
        _academicProgramServiceMock
            .Setup(s => s.GetAcademicPrograms(It.IsAny<GetAcademicProgramRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(paginatedList);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Single(result.Value.Results);
    }

    [Fact]
    public async Task GetAcademicProgramsFailure()
    {
        // Arrange
        var query = new GetAcademicProgramsQuery(1, 10);
        _academicProgramServiceMock
            .Setup(s => s.GetAcademicPrograms(It.IsAny<GetAcademicProgramRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Error.Failure("AcademicPrograms.Error", "Error al obtener programas academicos"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Equal(ErrorType.Failure, result.FirstError.Type);
    }
}
