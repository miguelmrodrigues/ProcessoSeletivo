using NHibernate;
using ProcessoSeletivo.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Category> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Category> FindAllSubcategories(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}