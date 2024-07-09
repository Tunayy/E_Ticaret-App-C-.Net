using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Commerce.Entities
{
    public class ProductsProperties
    {
        public int ProductId { get; set; }
        public Products Product { get; set; }

        public int PropertyId { get; set; }
        public Properties Property { get; set; }
    }
}
