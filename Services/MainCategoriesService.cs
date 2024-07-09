
using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services
    {
        public class MainCategoriesService
        {
            private readonly ECommerceDbContext _dbContext;

            public MainCategoriesService(ECommerceDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void AddMainCatagories(MainCategoriesRequestModel mainCategories)
            {
                var model = new MainCategories
                {
                    Name = mainCategories.Name,
                    Desc = mainCategories.Desc,
                    Status = true,

                };
                _dbContext.MainCategories.Add(model);
                _dbContext.SaveChanges();
            }

            public void DeleteMainCatagories(int id)
            {
                var CategoriesToDelete = _dbContext.MainCategories.Find(id);
                if (CategoriesToDelete != null)
                {
                    CategoriesToDelete.Status = false;
                    _dbContext.MainCategories.Update(CategoriesToDelete);
                    _dbContext.SaveChanges();
                }
            }

            public IEnumerable<MainCategories> GetMainCatagories()
            { 
                var mainCategories = _dbContext.MainCategories
                       .Include(c => c.Categories)
                       .ThenInclude(p => p.Products)
                       .ThenInclude(k => k.Images)
                       .ToList();

                 return mainCategories;
            }

            public MainCategories GetMainCatagoriesById(int id)
            {
                 var mainCategories = _dbContext.MainCategories
                        .Include(c => c.Categories)
                        .ThenInclude(p => p.Products)
                        .ThenInclude(k => k.Images)
                        .FirstOrDefault(c => c.Id == id);
                return mainCategories;
                        
            }

        public void UpdateMainCategories(int id, MainCategoriesUpdateRequestModel updatedCategories)
        {
            var existingCategory = _dbContext.MainCategories
                .Include(p => p.Categories)
                .FirstOrDefault(p => p.Id == id);

            if (existingCategory != null)
            {
                // Ürünün temel bilgilerini güncelle
                existingCategory.Name = updatedCategories.Name;
                existingCategory.Desc = updatedCategories.Desc;

                var existingProduct = existingCategory.Categories.ToList();

                //İmages operation
                foreach (var updatedProducts in existingProduct)
                {
                    updatedProducts.MainCategoriesId = existingCategory.Id;
                    updatedProducts.MainCatagories = existingCategory.Name;

                }


                _dbContext.MainCategories.Update(existingCategory);
                _dbContext.SaveChanges();
            }
        }


    }
    }



