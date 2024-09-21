using BlogApp.API.Models.Data;
using BlogApp.API.Models.Domain;
using BlogApp.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            this._dBContext = dBContext;
        }

        public async Task<Category> CreateAsync(Category category) 
        {
            await _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _dBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dBContext.Categories.ToListAsync();
        }

        public async Task<Category?> EditCategoryAsync(Category category)
        {
            var existingCategory =  await _dBContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existingCategory != null) 
            {
                _dBContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await _dBContext.SaveChangesAsync();

                return category;
            }

            return null;
        }

        public async Task<Category?> DeleteCategoryAsync(Guid id)
        {
            var existingCategory = await _dBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCategory is null)
                return null;

            _dBContext.Categories.Remove(existingCategory);
            await _dBContext.SaveChangesAsync();

            return existingCategory;

        }
    }
}
