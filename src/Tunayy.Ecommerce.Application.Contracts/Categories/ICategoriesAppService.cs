using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Tests;
using Volo.Abp.Application.Services;


namespace Tunayy.Ecommerce.Categories
{
    public interface ICategoriesAppService : ICrudAppService<CategoriesDto, CategoriesListDto, Guid, FilterCategoriesInputDto, CreateCategoriesInputDto, UpdateCategoriesInputDto>
    {
    }
}
