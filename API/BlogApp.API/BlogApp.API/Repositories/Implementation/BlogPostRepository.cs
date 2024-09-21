using BlogApp.API.Models.Data;
using BlogApp.API.Models.Domain;
using BlogApp.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public BlogPostRepository(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await _dbContext.BlogPosts.AddAsync(blogPost);
            await _dbContext.SaveChangesAsync();

            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _dbContext.BlogPosts.Include(x=>x.Categories).ToListAsync();
        }

        public async Task<BlogPost?> GetByIdAync(Guid id)
        {
            return await _dbContext.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);   
        }

        public async Task<BlogPost?> EditBlogPostAsync(BlogPost blogPost)
        {
            var existingBlogPost = await _dbContext.BlogPosts
                .Include(x=>x.Categories).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlogPost != null)
            {
                //Update blog post
                _dbContext.Entry(existingBlogPost).CurrentValues.SetValues(blogPost);

                //Update Categories
                existingBlogPost.Categories = blogPost.Categories;

                await _dbContext.SaveChangesAsync();

                return blogPost;
            }

            return null;
        }

        public async Task<BlogPost?> DeleteBlogPostAsync(Guid id)
        {
            var existingBlogPost = await _dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBlogPost is null)
                return null;

            _dbContext.BlogPosts.Remove(existingBlogPost);
            await _dbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
