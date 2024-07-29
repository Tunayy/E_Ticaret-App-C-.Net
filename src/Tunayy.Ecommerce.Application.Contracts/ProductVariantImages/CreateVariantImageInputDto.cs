using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tunayy.Ecommerce.ProductVariantImages
{
    public class CreateVariantImageInputDto
    {
        public string Url { get; set; }
        public Guid ProductVariantId { get; set; }
    }
}
