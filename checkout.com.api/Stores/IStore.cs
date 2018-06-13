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

        Task<T> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);
    }
}