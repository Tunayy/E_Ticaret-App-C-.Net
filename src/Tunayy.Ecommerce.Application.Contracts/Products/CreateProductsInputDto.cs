using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tunayy.Ecommerce.Products
{
    public class CreateProductsInputDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
