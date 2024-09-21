using BlogApp.API.DTO;
using BlogApp.API.Models.Domain;
using BlogApp.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            this._blogPostRepository = blogPostRepository;
        }

        //POST : {apibaseUrl}/api/blogposts
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBlogPostRequestDto request)
        {
            //Convert DTO to Domain model
            var blogPost = new BlogPost()
            {
                Title = request.Title,
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisbile = request.IsVisbile,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle
            };

            blogPost = await _blogPostRepository.CreateAsync(blogPost);

            //Convert Domain model back to DTO

            var response = new BlogPostDto()
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisbile= blogPost.IsVisbile,
                PublishedDate= blogPost.PublishedDate,
                ShortDescription= blogPost.ShortDescription,
                UrlHandle = blogPost.UrlHandle,
                Title = blogPost.Title
            };

            return Ok(response);
        }


        //GET : {apibaseUrl}/api/blogposts
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogposts = await _blogPostRepository.GetAllAsync();

            //Convert domain model to Dto

            var response = new List<BlogPostDto>();
            foreach(var blogPost in blogposts)
            {
                response.Add(new BlogPostDto()
                {
                    Id = blogPost.Id,
                    Author = blogPost.Author,
                    Content = blogPost.Content,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    IsVisbile = blogPost.IsVisbile,
                    PublishedDate = blogPost.PublishedDate,
                    ShortDescription = blogPost.ShortDescription,
                    UrlHandle = blogPost.UrlHandle,
                    Title = blogPost.Title
                });
            }

            return Ok(response);
        }
    }
}
