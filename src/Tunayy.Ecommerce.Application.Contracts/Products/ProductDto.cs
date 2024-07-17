using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Images;
using Tunayy.Ecommerce.Tables;

namespace Tunayy.Ecommerce.Products
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
        public List<ImageDto> Images { get; set; }

    }
}
