using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Errors;

namespace WebApi.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategoryaAll() 
        {
            var categories = await _categoryService.GetAll();
            
            if (categories == null)
            {
                return NotFound(new CodeErrorResponse(404, $"Aún no hay categorias registrados"));
            }

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound(new CodeErrorResponse(404, $"La categoria de Id {id} no existe"));
            }

            return category;
        }
    }
}