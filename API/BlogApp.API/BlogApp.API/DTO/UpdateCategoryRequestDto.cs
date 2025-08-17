namespace BlogApp.API.DTO
{
    public class UpdateCategoryRequestDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string UrlHandle { get; set; }
    }
}
