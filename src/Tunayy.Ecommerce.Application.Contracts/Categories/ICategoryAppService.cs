using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Tests;
using Volo.Abp.Application.Services;


namespace Tunayy.Ecommerce.Categories
{
    public interface ICategoryAppService : ICrudAppService<CategoryDto, CategoryListDto, Guid, FilterCategoryInputDto, CreateCategoryInputDto, UpdateCategoryInputDto>
    {
    }
}
