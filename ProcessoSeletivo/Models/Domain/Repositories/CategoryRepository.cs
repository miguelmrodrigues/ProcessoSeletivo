using NHibernate;
using NHibernate.Linq;
using ProcessoSeletivo.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISession _session;

        public CategoryRepository()
        {
            _session = MvcApplication.CurrentSession;
        }

        public Category FindById(int id)
        {
            try
            {
                return _session.Query<Category>().Where(c => c.id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            
        }

        public IList<Category> FindAll()
        {
            try
            {
                return _session.Query<Category>().Where(c => c.ParentCategory == null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public IList<Category> FindAllSubcategories(int id)
        {
            try
            {
                return _session.Query<Category>().Where(c => c.ParentCategory.id == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public void Save(Category obj)
        {
            try
            {
                 using (ITransaction transaction = _session.BeginTransaction())
                {                    
                    _session.Save(obj);
                    transaction.Commit();
                }   
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}