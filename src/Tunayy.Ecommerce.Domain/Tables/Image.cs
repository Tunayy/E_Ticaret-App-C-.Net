using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables
{
    
        public class Image : FullAuditedEntity<Guid>
        {
            public string Url { get; set; }

            public Guid ProductId { get; set; }
            public Product Product { get; set; }

        }
    
}
