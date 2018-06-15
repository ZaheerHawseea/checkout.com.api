using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    public class InMemoryOrderStore : IOrderStore<Order>
    {
        private static IList<Order> Orders { get; set; } = new List<Order>();

        public Task<Order> AddAsync(Order order)
        {
            order.Id = order.Id ?? Guid.NewGuid().ToString();

            Orders.Add(order);

            return Task.FromResult(order);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var orderToDelete = Orders.SingleOrDefault(o => o.Id == id);

            return Task.FromResult(orderToDelete != null ? Orders.Remove(orderToDelete) : false);
        }

        public Task<IQueryable<Order>> FindAllAsync()
        {
            return Task.FromResult(Orders.AsQueryable());
        }

        public Task<Order> FindByIdAsync(string id)
        {
            return Task.FromResult(Orders.SingleOrDefault(o => o.Id == id));
        }

        public Task<Order> UpdateAsync(string id, Order order)
        {
            var orderToUpdate = Orders.SingleOrDefault(o => o.Id == id);

            if (orderToUpdate == null) return Task.FromResult<Order>(null);

            order.Id = id;

            Orders.Remove(orderToUpdate);
            Orders.Add(order);

            return Task.FromResult(order);
        }

        public Task<int> Count()
        {
            return Task.FromResult(Orders.Count);
        }
    }
}
