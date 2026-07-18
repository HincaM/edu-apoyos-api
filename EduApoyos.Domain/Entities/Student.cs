namespace EduApoyos.Domain.Entities
{
    public class Student
    {
        private Student() { }

        public static Student Create(string userId, string documentNumber, int academicProgramId, int semester) 
            => new() { 
                UserId = userId,
                DocumentNumber = documentNumber,
                AcademicProgramId = academicProgramId,
                Semester = semester
            };

        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string DocumentNumber { get; set; }
        public int AcademicProgramId { get; set; }
        public int Semester { get; set; }
        public User? User { get; set; }
        public AcademicProgram? AcademicProgram { get; set; }
    }
}
