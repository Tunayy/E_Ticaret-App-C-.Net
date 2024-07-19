using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Categories;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.Products
{
    public class ProductsAppService : CrudAppService<Product, ProductDto, ProductListDto, Guid, FilterProductInputDto, CreateProductInputDto, UpdateProductInputDto>, IPdoructAppService
    {
        private IRepository<ProductProperty> _productPropertyRepository;
        public ProductsAppService(IRepository<Product, Guid> repository, IRepository<ProductProperty> productPropertyRepository) : base(repository)
        {
            _productPropertyRepository = productPropertyRepository;
        }

        public override async Task<PagedResultDto<ProductListDto>> GetListAsync(FilterProductInputDto input)
        {
            var query = await ReadOnlyRepository.GetQueryableAsync();
            query = query.Include(x => x.Images)
                .Include(x => x.Properties).ThenInclude(x=>x.Property);
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
            var item=new ProductProperty();
            item.ProductId = input.ProductId;
            item.PropertyId = input.PropertyId;

            await _productPropertyRepository.InsertAsync(item);
        }

        
    }
}
