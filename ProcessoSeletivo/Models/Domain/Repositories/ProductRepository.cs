using NHibernate;
using NHibernate.Linq;
using ProcessoSeletivo.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISession _session;

        public ProductRepository()
        {
            _session = MvcApplication.CurrentSession;
        }

        public IList<Product> FindAll()
        {
            try
            {
                return _session.Query<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Product> FindAllByCategory(int id)
        {
            try
            {
                return _session.Query<Category>().Where(c => c.id == id).Single().Products.ToList();  
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }           
        }

        public void Save(Product obj)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(obj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }                
            }            
        }
    }
}