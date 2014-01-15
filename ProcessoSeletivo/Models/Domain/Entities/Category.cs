using System.Collections.Generic;

namespace ProcessoSeletivo.Models.Domain.Entities
{
    public class Category 
    {
        public virtual int id { get; set; }        
        public virtual string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual IList<Category> ChildCategories { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
