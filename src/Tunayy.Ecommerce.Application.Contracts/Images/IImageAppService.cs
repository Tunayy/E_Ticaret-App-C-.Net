using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Products;
using Volo.Abp.Application.Services;

namespace Tunayy.Ecommerce.Images
{
    public interface IImageAppService : ICrudAppService<ImageDto, ImageListDto, Guid, FilterImageInputDto, CreateImageInputDto, UpdateImageInputDto>
    {
    }
}
