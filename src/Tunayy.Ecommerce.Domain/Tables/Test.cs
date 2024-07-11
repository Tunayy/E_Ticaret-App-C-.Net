using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables;

public class Test: FullAuditedEntity<Guid>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public List<TestTwo> TestTwos { get; set; }
}
