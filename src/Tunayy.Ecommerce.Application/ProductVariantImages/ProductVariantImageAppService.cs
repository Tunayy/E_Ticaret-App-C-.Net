using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Images;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.ProductVariantImages
{
    public class ProductVariantImageAppService : CrudAppService<ProductVariantImage, VariantImageDto, VariantImageListDto, Guid, FilterVariantImageInputDto, CreateVariantImageInputDto, UpdateVariantImageInputDto>, IVariantImageAppService
    {
        public ProductVariantImageAppService(IRepository<ProductVariantImage, Guid> repository) : base(repository)
        {

        }

    }
}
