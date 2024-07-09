using Microsoft.AspNetCore.Mvc;
using E_Commerce.Services;
using E_Commerce.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertiesService _propertiesService;
        public PropertiesController(PropertiesService propertiesService)
        {
            _propertiesService = propertiesService;
        }

        [HttpGet]
        public IActionResult GetProperties()
        {
            var properties = _propertiesService.GetProperties();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public IActionResult GetPropertiesById(int id)
        {
            var properties = _propertiesService.GetPropertiesById(id);
            if (properties == null)
            {
                return NotFound();
            }
            return Ok(properties);
        }

        [HttpPost]
        public IActionResult AddProperties(PropertiesRequestModel properties)
        {

            _propertiesService.AddProperties(properties);
            return Ok("Product added successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProperties(int id, PropertiesUpdateRequestModel updatedProperties)
        {
            _propertiesService.UpdateProperties(id, updatedProperties);

            return Ok("Property updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategories(int id)
        {
            var existingProduct = _propertiesService.GetPropertiesById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _propertiesService.DeleteProperties(id);

            return Ok("Product deleted successfully");
        }
    }
}
