using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    public class InMemoryItemStore : IItemStore<Item>
    {
        private static IList<Item> Items { get; set; } = new List<Item>();

        public Task<Item> AddAsync(Item item)
        {
            item.Id = item.Id ?? Guid.NewGuid().ToString();

            Items.Add(item);

            return Task.FromResult(item);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var itemToDelete = Items.SingleOrDefault(i => i.Id == id);

            return Task.FromResult(itemToDelete != null ? Items.Remove(itemToDelete) : false);
        }

        public Task<IQueryable<Item>> FindAllAsync()
        {
            return Task.FromResult(Items.AsQueryable());
        }

        public Task<Item> FindById(string id)
        {
            return Task.FromResult(Items.SingleOrDefault(i => i.Id == id));
        }

        public Task<Item> UpdateAsync(string id, Item item)
        {
            var itemToUpdate = Items.SingleOrDefault(i => i.Id == id);

            if (itemToUpdate == null) return Task.FromResult<Item>(null);

            item.Id = id;

            Items.Remove(itemToUpdate);
            Items.Add(item);

            return Task.FromResult(item);
        }
    }
}
