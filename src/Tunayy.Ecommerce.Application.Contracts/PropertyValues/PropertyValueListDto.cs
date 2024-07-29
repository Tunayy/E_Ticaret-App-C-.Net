using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tunayy.Ecommerce.PropertyValues
{
    public class PropertyValueListDto
    {
        public Guid Id { get; set; }
        public string PropertyValueName { get; set; }
        public Guid PropertyId { get; set; }
    }
}
