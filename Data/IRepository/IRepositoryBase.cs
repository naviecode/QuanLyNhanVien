using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        int? Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        bool SaveChanges();
    }
}
