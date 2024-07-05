using Microsoft.AspNetCore.Mvc;
using E_Commerce.Services;
using E_Commerce.Entities;
namespace E_Commerce.Controllers
{

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productService;

        public ProductsController(ProductsService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductRequestModel product)
        {
            _productService.AddProduct(product);
            return Ok("Product added successfully");
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts(); 
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductUpdateRequestModel updatedProduct)
        {
            _productService.UpdateProduct(id,updatedProduct);

            return Ok("Product updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);

            return Ok("Product deleted successfully");
        }
    }
}
                