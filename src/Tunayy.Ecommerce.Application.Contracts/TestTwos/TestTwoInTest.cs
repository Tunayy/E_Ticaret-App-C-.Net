using System;
using Volo.Abp.Application.Dtos;

namespace Tunayy.Ecommerce.TestTwos;

public class TestTwoInTest:FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
}
