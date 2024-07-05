using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.Services
{
    public class ProductsService
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductsService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(ProductRequestModel product)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Name == product.Categories);
            var model = new Products
            {
                Name = product.Name,
                Desc = product.Desc,
                Price = product.Price,
                Categories=product.Categories,
                CategoriesId = category.Id,
                Images = product.Images,
                Status=true,

            };
            _dbContext.Products.Add(model);
            _dbContext.SaveChanges();
            
        }

        public IEnumerable<Products> GetProducts()
        {
            return _dbContext.Products
                  .Include(p => p.Images)
                  .ToList();
        }

        public Products GetProductById(int id)
        {
            return _dbContext.Products
                   .Include(p => p.Images)
                   .FirstOrDefault(p => p.Id == id);
        }


        public void UpdateProduct(int id , ProductUpdateRequestModel updatedProduct)
        {
            var existingProduct = _dbContext.Products
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);

            if (existingProduct != null)
            {
                // Ürünün temel bilgilerini güncelle
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Desc = updatedProduct.Desc;

                var existingImage = existingProduct.Images.ToList();

                //İmages operation
                foreach (var updatedImage in existingImage)
                {
                    updatedImage.ProductsId = existingProduct.Id;
                    updatedImage.Products = existingProduct.Name;

                }


                _dbContext.Products.Update(existingProduct);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _dbContext.Products.Find(id);
            if (productToDelete != null)
            {
                productToDelete.Status = false;  
                _dbContext.Products.Update(productToDelete);  
                _dbContext.SaveChanges();
            }
        }
    }
}
