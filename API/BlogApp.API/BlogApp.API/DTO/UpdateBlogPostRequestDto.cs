namespace BlogApp.API.DTO
{
    public class UpdateBlogPostRequestDto
    {
        public required string Title { get; set; }
        public required string ShortDescription { get; set; }
        public required string Content { get; set; }
        public string FeaturedImageUrl { get; set; } = string.Empty;
        public required string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public required string UserId { get; set; }
        public bool IsVisbile { get; set; }
        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
