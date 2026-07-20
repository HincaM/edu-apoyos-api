using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Application.Features.Students.Queries.GetStudents
{
    public class StudentDto
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public string? UserName { get; set; }
        public required string DocumentNumber { get; set; }
        public required DocumentType DocumentType { get; set; }
        public int AcademicProgramId { get; set; }
        public string? AcademicProgramName { get; set; }
        public int Semester { get; set; }
    }
}
