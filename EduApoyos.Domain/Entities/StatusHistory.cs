using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Entities
{
    public class StatusHistory
    {
        private StatusHistory() { }
        public static StatusHistory Create(int requestSupportId, Status previousState, Status newState, int userId, string? observation)
            => new()
            {
                RequestSupportId = requestSupportId,
                PreviousState = previousState,
                NewState = newState,
                ChangeDate = DateTime.Now,
                UserId = userId,
                Observation = observation
            };

        public int Id { get; set; }
        public int RequestSupportId { get; set; }
        public Status PreviousState { get; set; }
        public Status NewState { get; set; }
        public DateTime ChangeDate { get; set; }
        public int UserId { get; set; }
        public string? Observation { get; set; }
        public User? User { get; set; }
        public RequestSupport? RequestSupport { get; set; }
    }
}
