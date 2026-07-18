using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Entities
{
    public class RequestSupport
    {
        private RequestSupport() { }

        public static RequestSupport Create(int studentId, TypeSupport typeSupport, double requestedAmount, string description, string advisorId)
            => new()
            {
                StudentId = studentId,
                TypeSupport = typeSupport,
                RequestedAmount = requestedAmount,
                Description = description,
                Status = Status.Pending,
                ApplicationDate = DateTime.Now,
                AdvisorId = advisorId,
            };
            
        public int Id { get; set; }
        public int StudentId { get; set; }
        public TypeSupport TypeSupport { get; set; }
        public double RequestedAmount { get; set; }
        public required string Description { get; set; }
        public Status Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? DateUpdated { get; set; }
        public required string AdvisorId { get; set; }
        public Student? Student { get; set; }
        public User? Advisor { get; set; }
    }
}
