using ProcessoSeletivo.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public interface IProductRepository
    {
        public IList<Product> FindAll();

        public IList<Product> FindAllByCategory(int id);

        public void Save(Product obj);
    }
}
