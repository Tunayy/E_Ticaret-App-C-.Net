using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.Tests;

public class TestAppService: CrudAppService<Test,TestDto,TestListDto,Guid,FilterTestInput,CreateTestInput,UpdateTestInput>,ITestAppService
{
    public TestAppService(IRepository<Test, Guid> repository) : base(repository)
    {
    }


    public override async Task<TestDto> GetAsync(Guid id)
    {

        await CheckGetPolicyAsync();

        var entity = await GetEntityByIdAsync(id);

        return await MapToGetOutputDtoAsync(entity);
    }


    protected override async Task<Test> GetEntityByIdAsync(Guid id)
    {
        var query = await ReadOnlyRepository.GetQueryableAsync();
        query = query.Include(x => x.TestTwos);

        var result = await query.FirstOrDefaultAsync(i => i.Id == id);
        return result!;
    }






    public override Task<PagedResultDto<TestListDto>> GetListAsync(FilterTestInput input)
    {
        return base.GetListAsync(input);
    }

    protected override Task<IQueryable<Test>> CreateFilteredQueryAsync(FilterTestInput input)
    {
        return base.CreateFilteredQueryAsync(input);
    }
}
