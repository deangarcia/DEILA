using System.Collections.Generic;
using System.Threading.Tasks;

namespace deila.backend.Services
{
    public interface IGenericRepo<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> Update(T model);
        Task SaveAsync();
        bool HasChanges();
        void Add(T model);
        void Remove(T model);
    }
}
