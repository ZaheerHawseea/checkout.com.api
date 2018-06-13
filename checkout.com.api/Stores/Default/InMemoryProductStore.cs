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
            Products.Add(product);

            return Task.FromResult(product);
        }

        public Task<bool> DeleteAsync(Product product)
        {
            var productToDelete = Products.Single(p => p.Id == product.Id);

            return Task.FromResult(productToDelete != null ? Products.Remove(productToDelete) : false);
        }

        public Task<IQueryable<Product>> FindAllAsync()
        {
            return Task.FromResult(Products.AsQueryable());
        }

        public Task<bool> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
