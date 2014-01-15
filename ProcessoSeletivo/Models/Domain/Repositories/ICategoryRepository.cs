using ProcessoSeletivo.Models.Domain.Entities;
using System.Collections.Generic;

namespace ProcessoSeletivo.Models.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Category FindById(int id);

        IList<Category> FindAll();

        IList<Category> FindAllSubcategories(int id);

        void Save(Category obj);
    }
}
