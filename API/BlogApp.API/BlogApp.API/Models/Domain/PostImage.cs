namespace BlogApp.API.Models.Domain
{
    public class PostImage
    {
        public Guid ImageId { get; set; }
        public required Guid PostId { get; set; }
        public required string ImageUrl { get; set; }
        public required DateTimeOffset UploadedOn { get; set; }
        public required BlogPost Post { get; set; } 
    }
}
