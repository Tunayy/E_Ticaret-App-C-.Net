using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.Categories
{
    public class CategoriesAppService : CrudAppService<Category, CategoriesDto, CategoriesListDto,Guid, FilterCategoriesInputDto, CreateCategoriesInputDto, UpdateCategoriesInputDto>, ICategoriesAppService
    {
        public CategoriesAppService(IRepository<Category, Guid> repository) : base(repository)
        {
            
        }


        protected override async Task<Category> GetEntityByIdAsync(Guid id)
        {
            var query = await ReadOnlyRepository.GetQueryableAsync();

            // Ana kategoriye ait alt kategorileri de dahil etmek için Include kullanabiliriz.
            query = query.Include(x => x.SubCategories)
                .ThenInclude(k => k.SubCategories);

            var result = await query.FirstOrDefaultAsync(i => i.Id == id);
            return result!;
        }

      
    }
}
