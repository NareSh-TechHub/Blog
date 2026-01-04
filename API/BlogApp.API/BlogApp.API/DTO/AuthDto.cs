namespace BlogApp.API.DTO
{
    public class RegisterRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required bool CreatorAccessRequested { get; set; }
    }

    public class LoginRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class AuthResponseDto
    {
        public required string UserId { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}