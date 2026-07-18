using EduApoyos.Domain.Common.Enum;

namespace EduApoyos.Domain.Entities
{
    public class User
    {
        private User() { }

        public static User Create(string id, string fullName, string email, string password, Role role)
            => new()
            {
                Id = id,
                FullName = fullName,
                Email = email,
                PasswordHash = password,
                Role = role,
                DateRegistration = DateTime.Now
            };

        public required string Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required Role Role { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
