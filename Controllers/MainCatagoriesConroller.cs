using Microsoft.AspNetCore.Mvc;
using E_Commerce.Services;
using E_Commerce.Entities;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/MainCategories")]
    public class MainCatagoriesConroller: ControllerBase
    {
        private readonly MainCategoriesService _maincategoriesService;
        public MainCatagoriesConroller(MainCategoriesService maincategoriesService)
        {
            _maincategoriesService = maincategoriesService;
        }

        [HttpPost]
        public IActionResult AddMainCategories(MainCategoriesRequestModel categories)
        {
            categories.Status = true;
            _maincategoriesService.AddMainCatagories(categories);
            return Ok("Product added successfully");
        }

        [HttpGet]
        public IActionResult GetMainCatagories()
        {

            var catagories = _maincategoriesService.GetMainCatagories();
            return Ok(catagories);
        }

        [HttpGet("{id}")]
        public IActionResult GetMainCatagoriesById(int id)
        {
            var categories = _maincategoriesService.GetMainCatagoriesById(id);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMainCategories(int id)
        {
            var existingProduct = _maincategoriesService.GetMainCatagoriesById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _maincategoriesService.DeleteMainCatagories(id);

            return Ok("Product deleted successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMainProduct(int id, MainCategoriesUpdateRequestModel updatedCategories)
        {
            _maincategoriesService.UpdateMainCategories(id, updatedCategories);

            return Ok("Product updated successfully");
        }
    }
}
