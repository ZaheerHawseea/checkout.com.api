using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores.Default
{
    /// <summary>
    /// In Memory implementation of <see cref="IProductStore{TProduct}"/>
    /// </summary>
    public class InMemoryProductStore : IProductStore<Product>
    {
        /// <summary>
        /// Static list of all products
        /// </summary>
        private static IList<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Add a product
        /// </summary>
        /// <param name="product">
        /// The product to add
        /// </param>
        /// <returns>
        /// The added product
        /// </returns>
        public Task<Product> AddAsync(Product product)
        {
            product.Id = product.Id ?? Guid.NewGuid().ToString();

            Products.Add(product);

            return Task.FromResult(product);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">
        /// The id of the product to delete
        /// </param>
        /// <returns>
        /// Success of delete operation
        /// </returns>
        public Task<bool> DeleteAsync(string id)
        {
            var productToDelete = Products.SingleOrDefault(p => p.Id == id);

            return Task.FromResult(productToDelete != null ? Products.Remove(productToDelete) : false);
        }

        /// <summary>
        /// Retrieve all products
        /// </summary>
        /// <returns>
        /// All products
        /// </returns>
        public Task<IQueryable<Product>> FindAllAsync()
        {
            return Task.FromResult(Products.AsQueryable());
        }

        /// <summary>
        /// Retrieve a product by id
        /// </summary>
        /// <param name="id">
        /// The id of the product to retrieve
        /// </param>
        /// <returns>
        /// The product
        /// </returns>
        public Task<Product> FindByIdAsync(string id)
        {
            return Task.FromResult(Products.SingleOrDefault(p => p.Id == id));
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">
        /// The id of the product to update
        /// </param>
        /// <param name="product">
        /// The updated product
        /// </param>
        /// <returns>
        /// The updated product
        /// </returns>
        public Task<Product> UpdateAsync(string id, Product product)
        {
            var productToUpdate = Products.SingleOrDefault(p => p.Id == id);

            if (productToUpdate == null) return Task.FromResult<Product>(null);

            product.Id = id;

            Products.Remove(productToUpdate);
            Products.Add(product);

            return Task.FromResult(product);
        }

        /// <summary>
        /// Count of products stored
        /// </summary>
        /// <returns>
        /// The count of products
        /// </returns>
        public Task<int> Count()
        {
            return Task.FromResult(Products.Count);
        }
    }
}
