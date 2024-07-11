using System;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.Tests;

public interface ITestAppService:ICrudAppService<TestDto,TestListDto,Guid,FilterTestInput,CreateTestInput,UpdateTestInput>
{

}
