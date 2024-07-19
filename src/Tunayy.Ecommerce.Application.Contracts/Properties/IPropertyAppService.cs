using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.Properties
{
    public interface IPropertyAppService : ICrudAppService<PropertyDto, PropertyListDto, Guid, FilterPropertyInputDto, CreatePropertyInputDto, UpdatePropertyInputDto>
    {
    }
}
