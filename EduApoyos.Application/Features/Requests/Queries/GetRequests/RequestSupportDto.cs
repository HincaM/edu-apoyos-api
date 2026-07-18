using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Application.Features.Requests.Queries.GetRequests
{
    public class RequestSupportDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public TypeSupport TypeSupport { get; set; }
        public string TypeSupportDescription => TypeSupport.GetDescription("");
        public double RequestedAmount { get; set; }
        public required string Description { get; set; }
        public Status Status { get; set; }
        public string StatusDescription => Status.GetDescription("");
        public DateTime ApplicationDate { get; set; }
        public DateTime? DateUpdated { get; set; }
        public required string AdvisorId { get; set; }
        public string? AdvisorName { get; set; }
    }
}
