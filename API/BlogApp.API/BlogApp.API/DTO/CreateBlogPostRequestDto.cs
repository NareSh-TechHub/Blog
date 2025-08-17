namespace BlogApp.API.DTO
{
    public class CreateBlogPostRequestDto
    {
        public required string Title { get; set; }
        public required string ShortDescription { get; set; }
        public required string Content { get; set; }
        public string FeaturedImageUrl { get; set; } = string.Empty;
        public required string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public required Guid UserId { get; set; }
        public bool IsVisbile { get; set; }

        public required Guid[] Categories { get; set; }
    }
}
