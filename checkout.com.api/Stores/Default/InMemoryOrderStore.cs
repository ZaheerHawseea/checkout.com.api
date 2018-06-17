using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    /// <summary>
    /// In Memory implementation of <see cref="IOrderStore{TOrder}"/>
    /// </summary>
    public class InMemoryOrderStore : IOrderStore<Order>
    {
        /// <summary>
        /// Static list of all orders
        /// </summary>
        private static IList<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Add an order
        /// </summary>
        /// <param name="order">
        /// The order to add
        /// </param>
        /// <returns>
        /// The added order
        /// </returns>
        public Task<Order> AddAsync(Order order)
        {
            order.Id = order.Id ?? Guid.NewGuid().ToString();

            if (!Orders.Any(o => o.Id == order.Id))
            {
                Orders.Add(order);
            }

            return Task.FromResult(order);
        }

        /// <summary>
        /// Delete an order
        /// </summary>
        /// <param name="id">
        /// The id of the order to delete
        /// </param>
        /// <returns>
        /// Success of delete operation
        /// </returns>
        public Task<bool> DeleteAsync(string id)
        {
            var orderToDelete = Orders.SingleOrDefault(o => o.Id == id);

            return Task.FromResult(orderToDelete != null ? Orders.Remove(orderToDelete) : false);
        }

        /// <summary>
        /// Retrieve all orders
        /// </summary>
        /// <returns>
        /// All orders
        /// </returns>
        public Task<IQueryable<Order>> FindAllAsync()
        {
            return Task.FromResult(Orders.AsQueryable());
        }

        /// <summary>
        /// Retrieve an order by id
        /// </summary>
        /// <param name="id">
        /// The id of the order to retrieve
        /// </param>
        /// <returns>
        /// The order
        /// </returns>
        public Task<Order> FindByIdAsync(string id)
        {
            return Task.FromResult(Orders.SingleOrDefault(o => o.Id == id));
        }

        /// <summary>
        /// Update an order
        /// </summary>
        /// <param name="id">
        /// The id of the order to update
        /// </param>
        /// <param name="order">
        /// The updated order
        /// </param>
        /// <returns>
        /// The updated order
        /// </returns>
        public Task<Order> UpdateAsync(string id, Order order)
        {
            var orderToUpdate = Orders.SingleOrDefault(o => o.Id == id);

            if (orderToUpdate == null) return Task.FromResult<Order>(null);

            order.Id = id;

            Orders.Remove(orderToUpdate);
            Orders.Add(order);

            return Task.FromResult(order);
        }

        /// <summary>
        /// Count of orders stored
        /// </summary>
        /// <returns>
        /// The count of orders
        /// </returns>
        public Task<int> Count()
        {
            return Task.FromResult(Orders.Count);
        }
    }
}
