using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Images;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.ProductVariants
{
    public interface IVariantAppService : ICrudAppService<VariantDto, VariantListDto, Guid, FilterVariantInputDto, CreateVariantInputDto, UpdateVariantInputDto>
    {
    }
}
