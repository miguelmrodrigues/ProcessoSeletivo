using ProcessoSeletivo.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> FindAll()
        {
            return new List<Product>();
            //throw new NotImplementedException();
        }

        public IList<Product> FindAllByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}