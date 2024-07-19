using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Tunayy.Ecommerce.Tables
{
    public class ProductProperty : FullAuditedEntity<Guid>
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
