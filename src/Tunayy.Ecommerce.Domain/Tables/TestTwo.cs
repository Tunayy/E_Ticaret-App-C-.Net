using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables;

public class TestTwo:FullAuditedEntity<Guid>
{
    public string Name { get; set; }
    public Guid TestId { get; set; }
    public Test Test { get; set; }
}
