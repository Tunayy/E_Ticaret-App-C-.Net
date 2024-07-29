using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Properties;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.PropertyValues
{
    public class PropertyValueAppService : CrudAppService<PropertyValue, PropertyValueDto, PropertyValueListDto, Guid, FilterPropertyValueInputDto, CreatePropertyValueInputDto, UpdatePropertyValueInputDto>, IPorpertyValueAppService
    {
        public PropertyValueAppService(IRepository<PropertyValue, Guid> repository) : base(repository)
        {

        }

    }
}
