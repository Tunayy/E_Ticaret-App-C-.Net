using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunayy.Ecommerce.Images;
using Tunayy.Ecommerce.ProductVariantImages;

namespace Tunayy.Ecommerce.ProductVariants
{
    public class VariantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Guid ProductId { get; set; }

        public List<VariantImageDto> ProductVariantImages { get; set; }
    }
}
