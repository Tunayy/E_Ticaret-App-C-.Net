using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Products;
using Tunayy.Ecommerce.Tables;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tunayy.Ecommerce.Images
{
    public class ImageAppService : CrudAppService<Image, ImageDto, ImageListDto, Guid, FilterImageInputDto, CreateImageInputDto, UpdateImageInputDto>, IImageAppService
    {
        public ImageAppService(IRepository<Image, Guid> repository) : base(repository)
        {

        }

    }
}
