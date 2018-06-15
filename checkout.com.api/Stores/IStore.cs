using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Stores
{
    public interface IStore<T>
        where T : IEntity
    {
        Task<IQueryable<T>> FindAllAsync();

        Task<T> FindByIdAsync(string id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(string id, T entity);

        Task<bool> DeleteAsync(string id);

        Task<int> Count();
    }
}