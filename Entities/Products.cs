using Swashbuckle.AspNetCore.Annotations;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.Entities
{
    public class Products
    {
        public int Id { get; set; }

        public bool Status { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public int CategoriesId { get; set; }
        public String Categories { get; set; }

        public ICollection<Images> Images { get; set; }

        public ICollection<ProductsProperties> Properties { get; set; }
    }

    public class ProductRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public string Categories { get; set; }
        
        public ICollection<int> Property { get; set; }
        public ICollection<Images> Images { get; set; }
    }

    public class ProductUpdateRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public string Categories { get; set; }

    }
}
