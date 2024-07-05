using Microsoft.AspNetCore.Mvc;
using E_Commerce.Services;
using E_Commerce.Entities;
namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly CatagoriesService _categoriesService;
        public CategoriesController(CatagoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpPost]
        public IActionResult AddCategories(Categories categories)
        {
            categories.Status=true;
            _categoriesService.AddCatagories(categories);
            return Ok("Product added successfully");
        }

        [HttpGet]
        public IActionResult GetCatagories()
        {
            
            var catagories = _categoriesService.GetCatagories();
            return Ok(catagories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCatagoriesById(int id)
        {
            var categories = _categoriesService.GetCatagoriesById(id);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, CategoriesUpdateRequestModel updatedCategories)
        {
            _categoriesService.UpdateCategories(id, updatedCategories);

            return Ok("Product updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategories(int id)
        {
            var existingProduct = _categoriesService.GetCatagoriesById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _categoriesService.DeleteCatagories(id);

            return Ok("Product deleted successfully");
        }
    }
}
