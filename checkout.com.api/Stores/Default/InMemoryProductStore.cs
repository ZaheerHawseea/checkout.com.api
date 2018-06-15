using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    public class InMemoryProductStore : IProductStore<Product>
    {
        private static IList<Product> Products { get; set; } = new List<Product>();

        public Task<Product> AddAsync(Product product)
        {
            product.Id = product.Id ?? Guid.NewGuid().ToString();

            Products.Add(product);

            return Task.FromResult(product);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var productToDelete = Products.SingleOrDefault(p => p.Id == id);

            return Task.FromResult(productToDelete != null ? Products.Remove(productToDelete) : false);
        }

        public Task<IQueryable<Product>> FindAllAsync()
        {
            return Task.FromResult(Products.AsQueryable());
        }

        public Task<Product> FindByIdAsync(string id)
        {
            return Task.FromResult(Products.SingleOrDefault(p => p.Id == id));
        }

        public Task<Product> UpdateAsync(string id, Product product)
        {
            var productToUpdate = Products.SingleOrDefault(p => p.Id == id);

            if (productToUpdate == null) return Task.FromResult<Product>(null);

            product.Id = id;

            Products.Remove(productToUpdate);
            Products.Add(product);

            return Task.FromResult(product);
        }

        public Task<int> Count()
        {
            return Task.FromResult(Products.Count);
        }
    }
}
