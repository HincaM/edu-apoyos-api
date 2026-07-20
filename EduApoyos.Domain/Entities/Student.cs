using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Entities
{
    public class Student
    {
        private Student() { }

        public static Student Create(int userId, string documentNumber, DocumentType documentType, int academicProgramId, int semester)
            => new() {
                UserId = userId,
                DocumentNumber = documentNumber,
                DocumentType = documentType,
                AcademicProgramId = academicProgramId,
                Semester = semester
            };

        public int Id { get; set; }
        public int UserId { get; set; }
        public required string DocumentNumber { get; set; }
        public required DocumentType DocumentType { get; set; }
        public int AcademicProgramId { get; set; }
        public int Semester { get; set; }
        public User? User { get; set; }
        public AcademicProgram? AcademicProgram { get; set; }
    }
}
