using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables
{
    public class Property : FullAuditedEntity<Guid>
    {
        public string PropertyName { get; set; }

        public List<ProductPropertyValue> Products { get; set; }

        public List<PropertyValue> PropertyValues { get; set; }

        
    }
}
