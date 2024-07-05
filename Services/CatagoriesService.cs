using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services
{
    public class CatagoriesService
    {
        private readonly ECommerceDbContext _dbContext;

        public CatagoriesService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCatagories(Categories categories)
        {
            
            _dbContext.Categories.Add(categories);
            _dbContext.SaveChanges();
        }

        public void DeleteCatagories(int id) 
        {
            var CategoriesToDelete = _dbContext.Categories.Find(id);
            if (CategoriesToDelete != null)
            {
                CategoriesToDelete.Status = false;
                _dbContext.Categories.Update(CategoriesToDelete);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Categories> GetCatagories()
        {
            return _dbContext.Categories
                   .Include(c => c.Products)
                   .ThenInclude(p => p.Images)
                   .ToList();
        }

        public Categories GetCatagoriesById(int id)
        {
            return _dbContext.Categories
                    .Include(c => c.Products)
                    .ThenInclude(p => p.Images)
                    .FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCategories(int id, CategoriesUpdateRequestModel updatedCategories)
        {
            var existingCategory = _dbContext.Categories
                .Include(p => p.Products)
                .FirstOrDefault(p => p.Id == id);

            if (existingCategory != null)
            {
                // Ürünün temel bilgilerini güncelle
                existingCategory.Name = updatedCategories.Name;
                existingCategory.Desc = updatedCategories.Desc;

                var existingProduct = existingCategory.Products.ToList();

                //İmages operation
                foreach (var updatedProducts in existingProduct)
                {
                    updatedProducts.CategoriesId = existingCategory.Id;
                    updatedProducts.Categories = existingCategory.Name;

                }


                _dbContext.Categories.Update(existingCategory);
                _dbContext.SaveChanges();
            }
        }


    }
}
