namespace BlogApp.API.DTO
{
    public class CreatorAccessRequestDto
    {
        public required string UserId { get; set; }
        public required string UserName { get; set; }
        public required DateTimeOffset RequestedAt { get; set; }
    }
}
