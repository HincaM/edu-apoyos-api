using EduApoyos.Domain.Enum;

namespace EduApoyos.Domain.Entities
{
    public class User
    {
        public required string Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required Rol Rol { get; set; }
    }
}
