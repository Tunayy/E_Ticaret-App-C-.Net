using E_Commerce.DataAccess.Contexts;
using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services
{
    public class PropertiesService
    {
        private readonly ECommerceDbContext _dbContext;

        public PropertiesService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Properties> GetProperties()
        {
            return _dbContext.Properties.ToList();
        }
        public Properties GetPropertiesById(int id)
        {
            return _dbContext.Properties.FirstOrDefault(i => i.Id == id);
        }

        public void AddProperties(PropertiesRequestModel properties)
        {

            var model = new Properties
            {
                PropertyName = properties.PropertyName, 
                Status = true,

            };
            _dbContext.Properties.Add(model);
            _dbContext.SaveChanges();

        }

        public void UpdateProperties(int id, PropertiesUpdateRequestModel updatedProperties)
        {
            var existingProperties = _dbContext.Properties
                .FirstOrDefault(p => p.Id == id);

            if (existingProperties != null)
            {
                // Ürünün temel bilgilerini güncelle
                existingProperties.PropertyName = updatedProperties.PropertyName;

                _dbContext.Properties.Update(existingProperties);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteProperties(int id)
        {
            var propertiesToDelete = _dbContext.Properties.Find(id);
            if (propertiesToDelete != null)
            {
                propertiesToDelete.Status = false;
                _dbContext.Properties.Update(propertiesToDelete);
                _dbContext.SaveChanges();
            }
        }


    }


}
