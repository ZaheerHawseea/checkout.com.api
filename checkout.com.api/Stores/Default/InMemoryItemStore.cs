using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    public class InMemoryItemStore : IItemStore<Item>
    {
        public Task<Item> AddAsync(Item entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Item entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Item>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
