using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables
{
    public class ProductVariant : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public List<ProductVariantImage> ProductVariantImages { get; set; }
    }
}
