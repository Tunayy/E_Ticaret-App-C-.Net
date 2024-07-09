using Swashbuckle.AspNetCore.Annotations;

namespace E_Commerce.Entities
{
    public class Properties
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public string PropertyName { get; set; }
        
        public ICollection<ProductsProperties> Products { get; set; }


    }

    public class PropertiesRequestModel
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public string PropertyName { get; set; }


    }

    public class PropertiesUpdateRequestModel
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public string PropertyName { get; set; }


    }
}
