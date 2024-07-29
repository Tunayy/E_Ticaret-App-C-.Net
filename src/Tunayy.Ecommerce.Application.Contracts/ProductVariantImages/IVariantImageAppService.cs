using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Images;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.ProductVariantImages
{
    public interface IVariantImageAppService : ICrudAppService<VariantImageDto, VariantImageListDto, Guid, FilterVariantImageInputDto, CreateVariantImageInputDto, UpdateVariantImageInputDto>
    {
    }
}
