using System;
using System.Collections.Generic;
using Tunayy.Ecommerce.TestTwos;
using Volo.Abp.Application.Dtos;

namespace Tunayy.Ecommerce.Tests;

public class TestDto:FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public List<TestTwoInTest> TestTwos { get; set; }
}
