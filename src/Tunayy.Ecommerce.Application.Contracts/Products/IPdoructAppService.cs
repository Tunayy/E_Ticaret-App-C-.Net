using System;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.Products
{
    public interface IPdoructAppService : ICrudAppService<ProductDto, ProductListDto, Guid, FilterProductInputDto, CreateProductInputDto, UpdateProductInputDto>
    {
    }
}
