﻿
using System.Collections.Generic;
namespace E_Commerce.Entities
{
    public class Categories
    {
        public int Id { get; set; }

        public bool Status { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public int MainCategoriesId { get; set; }
        public String MainCatagories { get; set; }
        public ICollection<Products> Products { get; set; }
    }


    public class CategoriesRequestModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public String MainCatagories { get; set; }


    }
    public class CategoriesUpdateRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        

    }
}
