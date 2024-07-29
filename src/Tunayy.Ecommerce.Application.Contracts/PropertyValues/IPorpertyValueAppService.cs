using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Products;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.PropertyValues
{
    public interface IPorpertyValueAppService : ICrudAppService<PropertyValueDto, PropertyValueListDto, Guid, FilterPropertyValueInputDto, CreatePropertyValueInputDto, UpdatePropertyValueInputDto>
    {
    }
}
