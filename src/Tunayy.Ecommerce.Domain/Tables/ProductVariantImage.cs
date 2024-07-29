using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables
{
    public class ProductVariantImage : FullAuditedEntity<Guid>
    {
        public string Url { get; set; }

        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
    }
}
