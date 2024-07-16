using System;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.Products
{
    public interface IPdoructsAppService : ICrudAppService<ProductsDto, ProductsListDto, Guid, FilterProductsInputDto, CreateProductsInputDto, UpdateProductsInputDto>
    {
    }
}
