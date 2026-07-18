using EduApoyos.Domain.Common.Enum;

namespace EduApoyos.Domain.Entities
{
    public class StatusHistory
    {
        public int Id { get; set; }
        public int RequestSupportId { get; set; }
        public Status PreviousState { get; set; }
        public Status NewState { get; set; }
        public DateTime ChangeDate { get; set; }
        public required string UserId { get; set; }
        public string? Observation { get; set; }
        public User? User { get; set; }
        public RequestSupport? RequestSupport { get; set; }
    }
}
