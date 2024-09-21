using BlogApp.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApp.API.Models.Domain;
using BlogApp.API.Models.Data;
using BlogApp.API.Repositories.Interface;
using BlogApp.API.Repositories.Implementation;
using System.ComponentModel;


namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository CategoryRepository)
        {
            this._categoryRepository = CategoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryRequestDto request)
        {
            //DTO objects are for decoupling and securing actual domain objects that are
            //being conected to DB tables with clients.
            //In this case client will be transferring data with server via DTO objects
            //and not the actual domain objects

            var category = new Category()
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await _categoryRepository.CreateAsync(category);

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                CategoryName = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(categoryDto);
        }

        //GET : https://localhost:7097/api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            var response = new List<CategoryDto>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDto()
                {
                    Id = category.Id,
                    CategoryName = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }

        //GET : https://localhost:7097/api/Categories/{id}
        [HttpGet]
        [Route("{id:Guid}")] //Making the route typesafe
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);

            if(existingCategory == null)
                return NotFound();

            var response = new CategoryDto()
            {
                Id = existingCategory.Id,
                CategoryName = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };

            return Ok(response);
        }

        //PUT : https://localhost:7097/api/Categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequestDto request)
        {
            //Convert Dto Object to Domain 
            var category = new Category()
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            var updatedCategory = await _categoryRepository.EditCategoryAsync(category);

            if(updatedCategory == null)
            {
                return NotFound();
            }

            var response = new CategoryDto()
            {
                Id= updatedCategory.Id,
                CategoryName = updatedCategory.Name,
                UrlHandle = updatedCategory.UrlHandle
            };

            return Ok(response);
        }

        //DELETE:https://localhost:7097/api/Categories/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await _categoryRepository.DeleteCategoryAsync(id);

            if(category is null)
                return NotFound();

            var response = new CategoryDto()
            {
                Id = category.Id,
                CategoryName = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
    }
}
