using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.ProductVariants
{
    public class CreateVariantAppService
    {
        private IRepository<ProductPropertyValue> _productPropertyRepository;
        private IRepository<PropertyValue> _propertyValueRepository;
        private IRepository<Property> _propertyRepository;
        public CreateVariantAppService(IRepository<ProductPropertyValue> productPropertyRepository, IRepository<PropertyValue> propertyValueRepository, IRepository<Property> propertyRepository)
        {
            _productPropertyRepository = productPropertyRepository;
            _propertyValueRepository = propertyValueRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<List<List<string>>> GenerateAllVariantValue(Guid target)
        {
            var item = await _productPropertyRepository.ToListAsync();
            var valuesprop = await _propertyValueRepository.ToListAsync();
            var namesprop = await _propertyRepository.ToListAsync();

            List<List<string>> allproperty = new List<List<string>>();


            var groupedProperty = item
                .Where(p => p.ProductId == target)
                .GroupBy(p => p.PropertyId)
                                      .Select(g => new
                                      {
                                          PropertyId = g.Key,
                                          Values = g.ToList()
                                      });


            foreach (var group in groupedProperty)
            {
                // Her seferinde tek bir property valuelarını tutmak için
                List<string> propValuesNameList = new List<string>();

                foreach (var value in group.Values)
                {
                    
                    string deneme = value.Property.PropertyName +":"+ value.PropertyValue.PropertyValueName;

                    propValuesNameList.Add(deneme);
                }
                allproperty.Add(propValuesNameList);
            }



               return allproperty;
        }


        public List<string> GenerateCombinations(List<List<string>> allproperty, string productName)
        {
            var combinations = new List<string>();
            GenerateCombinationsRecursive(allproperty, 0, new List<string>(), combinations, productName);
            return combinations;
        }


        private void GenerateCombinationsRecursive(List<List<string>> allproperty, int depth, List<string> currentCombination, List<string> combinations, string productName)
        {
            if (depth == allproperty.Count)
            {
                // Kombinasyon tamamlandığında, sonucu ekle
                var combination = $"{productName} " + string.Join(" ", currentCombination);
                combinations.Add(combination);
                return;
            }

            foreach (var value in allproperty[depth])
            {
                var newCombination = new List<string>(currentCombination) { value };
                GenerateCombinationsRecursive(allproperty, depth + 1, newCombination, combinations, productName);
            }
        }
    }
}
