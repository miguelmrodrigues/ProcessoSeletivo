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
        IList<Product> FindAll();

        IList<Product> FindAllByCategory(int id);

        void Save(Product obj);
    }
}
