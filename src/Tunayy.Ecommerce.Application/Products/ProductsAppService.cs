using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Categories;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.Products
{
    public class ProductsAppService : CrudAppService<Product, ProductsDto, ProductsListDto, Guid, FilterProductsInputDto, CreateProductsInputDto, UpdateProductsInputDto>, IPdoructsAppService
    {
        public ProductsAppService(IRepository<Product, Guid> repository) : base(repository)
        {

        }

      
    }
}
