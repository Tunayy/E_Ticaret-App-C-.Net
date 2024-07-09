
using System.Collections.Generic;
namespace E_Commerce.Entities
{
    public class MainCategories
    {
        public int Id { get; set; }

        public bool Status { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public ICollection<Categories> Categories { get; set; }
    }


    public class MainCategoriesRequestModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }


    }
    public class MainCategoriesUpdateRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }


    }
}
