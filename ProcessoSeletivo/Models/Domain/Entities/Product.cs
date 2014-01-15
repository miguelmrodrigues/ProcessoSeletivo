using System.Collections.Generic;

namespace ProcessoSeletivo.Models.Domain.Entities
{
    public class Product
    {
        public virtual int id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Category> Categories { get; set; }
    }
}