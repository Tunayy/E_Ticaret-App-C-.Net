using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Tunayy.Ecommerce.Tables
{
    public class Category:FullAuditedEntity<Guid>
    {
         public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public List<Category> SubCategories { get; set; }

        //public Category()
        //{
        //    SubCategories = new List<Category>();
        //}
    }
}
