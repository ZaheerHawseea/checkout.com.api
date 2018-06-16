using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    /// <summary>
    /// In Memory implementation of <see cref="IItemStore{TItem}"/>
    /// </summary>
    public class InMemoryItemStore : IItemStore<Item>
    {
        /// <summary>
        /// Static list of all items
        /// </summary>
        private static IList<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item">
        /// The item to add
        /// </param>
        /// <returns>
        /// The added item
        /// </returns>
        public Task<Item> AddAsync(Item item)
        {
            item.Id = item.Id ?? Guid.NewGuid().ToString();

            Items.Add(item);

            return Task.FromResult(item);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">
        /// The id of the item to delete
        /// </param>
        /// <returns>
        /// Success of delete operation
        /// </returns>
        public Task<bool> DeleteAsync(string id)
        {
            var itemToDelete = Items.SingleOrDefault(i => i.Id == id);

            return Task.FromResult(itemToDelete != null ? Items.Remove(itemToDelete) : false);
        }

        /// <summary>
        /// Retrieve all items
        /// </summary>
        /// <returns>
        /// All items
        /// </returns>
        public Task<IQueryable<Item>> FindAllAsync()
        {
            return Task.FromResult(Items.AsQueryable());
        }

        /// <summary>
        /// Retrieve an item by id
        /// </summary>
        /// <param name="id">
        /// The id of the item to retrieve
        /// </param>
        /// <returns>
        /// The item
        /// </returns>
        public Task<Item> FindByIdAsync(string id)
        {
            return Task.FromResult(Items.SingleOrDefault(i => i.Id == id));
        }

        public Task<IQueryable<Item>> FindByOrderIdAsync(string orderId)
        {
            return Task.FromResult(Items.Where(i => i.OrderId == orderId).AsQueryable());
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="id">
        /// The id of the item to update
        /// </param>
        /// <param name="item">
        /// The updated item
        /// </param>
        /// <returns>
        /// The updated item
        /// </returns>
        public Task<Item> UpdateAsync(string id, Item item)
        {
            var itemToUpdate = Items.SingleOrDefault(i => i.Id == id);

            if (itemToUpdate == null) return Task.FromResult<Item>(null);

            item.Id = id;

            Items.Remove(itemToUpdate);
            Items.Add(item);

            return Task.FromResult(item);
        }

        /// <summary>
        /// Count of items stored
        /// </summary>
        /// <returns>
        /// The count of items
        /// </returns>
        public Task<int> Count()
        {
            return Task.FromResult(Items.Count);
        }
    }
}
