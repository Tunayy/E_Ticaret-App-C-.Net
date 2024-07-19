using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tunayy.Ecommerce.Products
{
    public class CreateProductPropertyInputDto
    {
        public Guid ProductId { get; set; }
        public Guid PropertyId { get; set; }
    }
}
