using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    public class InMemoryOrderStore : IOrderStore<Order>
    {
        public Task<Order> AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Order>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
