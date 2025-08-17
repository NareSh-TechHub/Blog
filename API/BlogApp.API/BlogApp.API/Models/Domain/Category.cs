namespace BlogApp.API.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public required string UrlHandle { get; set; }
        public ICollection<BlogPost>? BlogPosts { get; set; }
    }
}
