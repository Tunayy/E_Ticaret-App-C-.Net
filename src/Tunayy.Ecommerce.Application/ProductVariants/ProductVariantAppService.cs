using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Products;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.ProductVariants
{
    public class ProductVariantAppService : CrudAppService<ProductVariant, VariantDto, VariantListDto, Guid, FilterVariantInputDto, CreateVariantInputDto, UpdateVariantInputDto>, IVariantAppService
    {
        public ProductVariantAppService(IRepository<ProductVariant, Guid> repository) : base(repository)
        {

        }
        public override async Task<PagedResultDto<VariantListDto>> GetListAsync(FilterVariantInputDto input)
        {

            var query = await ReadOnlyRepository.GetQueryableAsync();
            query = query.Include(x => x.ProductVariantImages);
                

            var result = await query.ToListAsync();
            return await base.GetListAsync(input);
        }

        protected override async Task<ProductVariant> GetEntityByIdAsync(Guid id)
        {
            var query = await ReadOnlyRepository.GetQueryableAsync();
            query = query.Include(x => x.ProductVariantImages);

            var result = await query.FirstOrDefaultAsync(i => i.Id == id);
            return result!;
        }

    }
}
