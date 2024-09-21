using BlogApp.API.Models.Domain;
using System.Collections;

namespace BlogApp.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAync(Guid id);
        Task<BlogPost?> EditBlogPostAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteBlogPostAsync(Guid id);
    }
}
