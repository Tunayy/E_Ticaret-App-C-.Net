using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Tunayy.Ecommerce.Categories
{
    public class CategoryListDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
        public Guid? ParentCategoryId { get; set; }
        

       


    }
}
