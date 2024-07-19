using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Products;
using Tunayy.Ecommerce.Properties;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.ProductsProperties
{
    public class PropertyAppServis : CrudAppService<Property, PropertyDto, PropertyListDto, Guid, FilterPropertyInputDto, CreatePropertyInputDto, UpdatePropertyInputDto>, IPropertyAppService
    {
        public PropertyAppServis(IRepository<Property, Guid> repository) : base(repository)
        {

        }
    }
}
