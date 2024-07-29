using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables
{
    public class PropertyValue : FullAuditedEntity<Guid>
    {
        public string PropertyValueName { get; set; }

        public List<ProductPropertyValue> PropertyValues { get; set; }

        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
