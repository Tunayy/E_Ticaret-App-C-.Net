using System;


namespace Tunayy.Ecommerce.Products
{
    public class UpdateProductInputDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
