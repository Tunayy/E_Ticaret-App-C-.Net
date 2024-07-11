using System;
using Volo.Abp.Application.Dtos;

namespace Tunayy.Ecommerce.Tests;

public class TestListDto:EntityDto<Guid>
{
    public string Name { get; set; }
}
