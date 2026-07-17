namespace EduApoyos.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string DocumentNumber { get; set; }
        public int AcademicProgramId { get; set; }
        public int Semester { get; set; }

    }
}
