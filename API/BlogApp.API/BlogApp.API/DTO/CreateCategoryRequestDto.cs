namespace BlogApp.API.DTO
{
    public class CreateCategoryRequestDto
    {
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
        public required string UrlHandle { get; set; }
    }
}
