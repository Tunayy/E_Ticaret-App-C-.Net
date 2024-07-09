using Microsoft.AspNetCore.Mvc;
using E_Commerce.Services;
using E_Commerce.Entities;
using E_Commerce.Entities;
using Microsoft.AspNetCore.Authorization;
namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImagesController : ControllerBase
    {
        private readonly ImagesService _imagesService;

        public ImagesController(ImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpPost]
        public IActionResult AddImages(ImagesRequestModel images)
        {
            
            _imagesService.AddImages(images);
            return Ok("Product added successfully");
        }

        [HttpGet]
        public IActionResult GetImages()
        {
            var images = _imagesService.GetImages();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public IActionResult GetImagesById(int id)
        {
            var images = _imagesService.GetImagesById(id);
            if (images == null)
            {
                return NotFound();
            }
            return Ok(images);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ImagesRequestModel updateImages)
        {
            _imagesService.UpdateImages(id, updateImages);

            return Ok("Product updated successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteImages(int id)
        {
            var existingImages = _imagesService.GetImagesById(id);
            if (existingImages == null)
            {
                return NotFound();
            }

            _imagesService.DeleteImages(id);

            return Ok("Product deleted successfully");
        }
    }
}
