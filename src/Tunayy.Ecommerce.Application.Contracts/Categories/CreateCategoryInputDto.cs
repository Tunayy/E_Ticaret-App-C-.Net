using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tunayy.Ecommerce.Categories
{
    public class CreateCategoryInputDto
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
