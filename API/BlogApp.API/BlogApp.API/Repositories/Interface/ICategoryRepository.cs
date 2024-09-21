using BlogApp.API.Models.Domain;

namespace BlogApp.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category?> EditCategoryAsync(Category category);
        Task<Category?> DeleteCategoryAsync(Guid id);
    }
}
