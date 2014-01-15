using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IList<Entities.Product> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Product> FindAllByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Entities.Product obj)
        {
            throw new NotImplementedException();
        }
    }
}