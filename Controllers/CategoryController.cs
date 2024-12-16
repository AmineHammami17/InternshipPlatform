using InternshipPlatform.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {   
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;     
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult <List<InternshipCategory>>> GetAllCategories()
        {
            return await _categoryService.GetAllCategories();
        }
        [HttpGet("GetSingleCategory/{id}")]

        public async Task<ActionResult<InternshipCategory>> GetSingleCategory(int id)
        {
            var result = await _categoryService.GetSingleCategory(id);
            if (result is null)
            {
                return NotFound("Sorry,Category doesn't exist");
            }
            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult<List<InternshipCategory>>> AddCategory(InternshipCategory category)
        {
            var result = await _categoryService.AddCategory(category);
            return Ok(result);

        }
        [HttpPut("UpdateCategory/{id}")]
        public async Task<ActionResult<List<InternshipCategory>>> UpdateCategory(int id, InternshipCategory request)
        {
            var result = await _categoryService.UpdateCategory(id,request);
            if (result is null)
            {
                return NotFound("Sorry,Category doesn't exist");
            }
            return Ok(result);

        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ActionResult<List<InternshipCategory>>> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if(result is null)
            {
                return NotFound("Sorry,Category doesn't exist");
            }
            return Ok(result);
        }

    }
}
