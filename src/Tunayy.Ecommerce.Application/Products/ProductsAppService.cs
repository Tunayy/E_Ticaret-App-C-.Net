using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Categories;
using Tunayy.Ecommerce.ProductVariants;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.Products
{
    public class ProductsAppService : CrudAppService<Product, ProductDto, ProductListDto, Guid, FilterProductInputDto, CreateProductInputDto, UpdateProductInputDto>, IPdoructAppService
    {
        private IRepository<ProductPropertyValue> _productPropertyRepository;
        private IRepository<ProductVariant> _productVariantRepository;
        private IRepository<PropertyValue> _propertyValueRepository;
        private IRepository<Property> _propertyRepository;
        public ProductsAppService(IRepository<Product, Guid> repository, IRepository<ProductPropertyValue> productPropertyRepository,  IRepository<PropertyValue> propertyValueRepository, IRepository<ProductVariant> productVariantRepository , IRepository<Property> propertyRepository) : base(repository)
        {
            _productPropertyRepository = productPropertyRepository;
            _propertyValueRepository = propertyValueRepository;
            _productVariantRepository = productVariantRepository;
            _propertyRepository = propertyRepository;
        }

        public override async Task<PagedResultDto<ProductListDto>> GetListAsync(FilterProductInputDto input)
        {

            var query = await ReadOnlyRepository.GetQueryableAsync();
            query = query.Include(x => x.Images)
                .Include(x => x.Properties).ThenInclude(x => x.Property).ThenInclude(x => x.PropertyValues);
                
            var result = await query.ToListAsync();
            return await base.GetListAsync(input);
        }

        protected override async Task<Product> GetEntityByIdAsync(Guid id)
        {
            var query = await ReadOnlyRepository.GetQueryableAsync();
            query = query.Include(x => x.Images);

            var result = await query.FirstOrDefaultAsync(i => i.Id == id);
            return result!;
        }

        public async Task CreateProductProperty(CreateProductPropertyInputDto input)
        {
            var item=new ProductPropertyValue();
            item.ProductId = input.ProductId;
            item.PropertyId = input.PropertyId;
            item.PropertyValueId = input.PropertyValueId;

            await _productPropertyRepository.InsertAsync(item);

        }

       
        public async Task CreateVariant(Guid guid)
        {
            var existingItems = await _productVariantRepository.GetListAsync(p => p.ProductId == guid);

            if (existingItems != null)
            {
                foreach (var item in existingItems)
                {
                    await _productVariantRepository.DeleteAsync(item);
                }

            }
           
            var productPropertyService = new CreateVariantAppService(_productPropertyRepository, _propertyValueRepository, _propertyRepository);
            var allproperties = await productPropertyService.GenerateAllVariantValue(guid);
            Product product = await GetEntityByIdAsync(guid);
      

            var variantAppService = new CreateVariantAppService(_productPropertyRepository, _propertyValueRepository, _propertyRepository);
            var variants = variantAppService.GenerateCombinations(allproperties, product.Name);
            Guid newGuid = Guid.NewGuid();
            foreach (var variant in variants)
            {
                var variantItem = new ProductVariant
                {
                    Name = variant,
                    Desc = variant,
                    Price = 0,
                    Stock = 0,
                    ProductId = guid
                };
                await _productVariantRepository.InsertAsync(variantItem);
               
            }
         
        }

    }
}
