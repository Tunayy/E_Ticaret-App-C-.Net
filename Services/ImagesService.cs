using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services
{
    public class ImagesService
    {
        private readonly ECommerceDbContext _dbContext;

        public ImagesService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddImages(ImagesRequestModel images)
        {
            var products = _dbContext.Products.FirstOrDefault(c => c.Name == images.Products);
            var model = new Images
            {   
                Url = images.Url,
                Products = images.Products,
                ProductsId = products.Id,
                Status=true
                
            };
            _dbContext.Images.Add(model);
            _dbContext.SaveChanges();

        }

        public IEnumerable<Images> GetImages()
        {
            return _dbContext.Images.ToList();
        }


        public Images GetImagesById(int id)
        {
            return _dbContext.Images.FirstOrDefault(i => i.Id == id);
        }
        public void UpdateImages(int id, ImagesRequestModel updateImages)
        {
            var existingImages = _dbContext.Images
                .FirstOrDefault(p => p.Id == id);

            if (existingImages != null)
            {
                // Ürünün temel bilgilerini güncelle
                existingImages.Url = updateImages.Url;
                existingImages.Products = updateImages.Products;

                var imagesProducts= _dbContext.Products.ToList();

                //İmages operation
                foreach (var updatedImage in imagesProducts)
                {   
                    if (updatedImage.Name==updateImages.Products)
                    {
                        existingImages.ProductsId = updatedImage.Id;
                    }
                    

                }


                _dbContext.Images.Update(existingImages);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteImages(int id) 
        {
            var ImagesToDelete = _dbContext.Images.Find(id);
            if (ImagesToDelete != null)
            {
                ImagesToDelete.Status = false;
                _dbContext.Images.Update(ImagesToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
