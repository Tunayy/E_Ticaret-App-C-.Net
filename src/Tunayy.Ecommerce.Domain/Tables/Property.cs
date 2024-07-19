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

        public ICollection<ProductProperty> Products { get; set; }
    }
}
