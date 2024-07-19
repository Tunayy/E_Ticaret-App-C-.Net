using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables
{
    public class Product : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Image> Images { get; set; }

        public List<ProductProperty> Properties { get; set; }

    }
}
