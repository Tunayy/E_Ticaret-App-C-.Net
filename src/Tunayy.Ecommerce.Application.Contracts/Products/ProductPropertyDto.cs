using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Properties;
using Tunayy.Ecommerce.PropertyValues;

namespace Tunayy.Ecommerce.Products
{
    public class ProductPropertyDto
    {
        public PropertyDto Property { get; set; }

        public PropertyValueDto PropertyValue { get; set; }
    }
}
