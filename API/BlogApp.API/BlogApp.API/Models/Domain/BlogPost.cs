using Microsoft.AspNetCore.Identity;

namespace BlogApp.API.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string ShortDescription { get; set; }
        public required string Content { get; set; }
        public string FeaturedImageUrl { get; set; } = string.Empty;
        public required string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public required string UserId { get; set; }
        public bool IsVisbile { get; set; }
        public IdentityUser? User { get; set; } 
        public required ICollection<Category> Categories { get; set; }

    }
}
