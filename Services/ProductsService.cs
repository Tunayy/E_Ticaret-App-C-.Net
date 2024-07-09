using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities;
using Microsoft.AspNetCore.Mvc;
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
                Properties = product.Property?.Select(propertyId => new ProductsProperties
                {
                    ProductId = product.Id, 
                    PropertyId = propertyId
                }).ToList(),
                Status =true,

            };

           
            _dbContext.Products.Add(model);
            _dbContext.SaveChanges();
            
        }

        public ActionResult<IEnumerable<object>> GetAllProducts()
        {
            var products = _dbContext.Products
                .Include(p => p.Images)
                .Include(p => p.Properties)
                    .ThenInclude(pp => pp.Property)
                .ToList();

            var response = products.Select(product => new
            {
                id = product.Id,
                status = product.Status,
                name = product.Name,
                desc = product.Desc,
                price = product.Price,
                categoriesId = product.CategoriesId,
                categories = product.Categories,
                images = product.Images.Select(i => new
                {
                    id = i.Id,
                    status = i.Status,
                    url = i.Url
                }).ToList(),
                properties = product.Properties.Select(pp => new
                {
                    productId = pp.ProductId,
                    propertyId = pp.PropertyId,
                    property = new
                    {
                        id = pp.Property.Id,
                        status = pp.Property.Status,
                        propertyName = pp.Property.PropertyName
                    }
                }).ToList()
            }).ToList();

            return response;
        }



        public ActionResult<object> GetProductById(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.Images)
                .Include(p => p.Properties)
                    .ThenInclude(pp => pp.Property)
                .SingleOrDefault(p => p.Id == id);

            
            // Veritabanı sorgusundan gelen veriyi temizleme
            var response = new
            {
                id = product.Id,
                status = product.Status,
                name = product.Name,
                desc = product.Desc,
                price = product.Price,
                categoriesId = product.CategoriesId,
                categories = product.Categories,
                images = product.Images.Select(i => new
                {
                    id = i.Id,
                    status = i.Status,
                    url = i.Url
                }).ToList(),
                properties = product.Properties.Select(pp => new
                {
                    productId = pp.ProductId,
                    propertyId = pp.PropertyId,
                    property = new
                    {
                        id = pp.Property.Id,
                        status = pp.Property.Status,
                        propertyName = pp.Property.PropertyName
                    }
                }).ToList()
            };

            return response;
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
