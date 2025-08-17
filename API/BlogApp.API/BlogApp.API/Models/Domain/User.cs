namespace BlogApp.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Guid RoleId { get; set; }

        public required Role Role { get; set; }
    }
}
