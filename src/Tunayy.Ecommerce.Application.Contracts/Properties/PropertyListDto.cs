using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.PropertyValues;

namespace Tunayy.Ecommerce.Properties
{
    public class PropertyListDto
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; }

        public List<PropertyValueDto> PropertyValues { get; set; }
    }
}
