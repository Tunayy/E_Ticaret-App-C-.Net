using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;



namespace Tunayy.Ecommerce.Tables
{
    public class ProductPropertyValue : FullAuditedEntity<Guid>
    {

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid PropertyId { get; set; }
        public Property Property { get; set; }

        public Guid PropertyValueId { get; set; }
        public PropertyValue PropertyValue { get; set; }

    }
}
