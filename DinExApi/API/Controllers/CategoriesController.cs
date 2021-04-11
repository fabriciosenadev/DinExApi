using DinExApi.Application.Interfaces;
using DinExApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategory(int usuarioID)
        {
            var categories = _categoryService.FindAllAsync(); //usuarioID
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int usuarioID, int categoryID)
        {
            var category = await _categoryService.FindByIdAsync(usuarioID, categoryID);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }
    }
}
