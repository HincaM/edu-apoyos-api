namespace EduApoyos.Application.Features.AcademicPrograms.Queries.GetAcademicPrograms
{
    public class AcademicProgramDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
