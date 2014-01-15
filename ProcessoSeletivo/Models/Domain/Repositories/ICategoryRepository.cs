using ProcessoSeletivo.Models.Domain.Entities;
using System.Collections.Generic;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public interface ICategoryRepository
    {
        public Category FindById(int id);

        public IList<Category> FindAll();

        public IList<Category> FindAllSubcategories(int id);

        public void Save(Category obj);
    }
}
