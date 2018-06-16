using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using checkout.com.api.test.Fixture;

namespace checkout.com.api.test.Extension
{
    /// <summary>
    /// Extension methods for the <see cref="IProductStore{TProduct}"/> store
    /// </summary>
    public static class ProductStoreExtensions
    {
        /// <summary>
        /// Populate the product test data
        /// </summary>
        /// <param name="productStore">
        /// The <see cref="IProductStore{TProduct}"/> instance
        /// </param>
        public static async void Seed(this IProductStore<Product> productStore)
        {
            foreach (var product in TestData.Products)
            {
                await productStore.AddAsync(product);
            }
        }
    }

    /// <summary>
    /// Extension methods for the <see cref="IItemStore{TItem}"/> store
    /// </summary>
    public static class ItemStoreExtensions
    {
        /// <summary>
        /// Populate the product test data
        /// </summary>
        /// <param name="itemStore">
        /// The <see cref="IItemStore{TItem}"/> instance
        /// </param>
        public static async void Seed(this IItemStore<Item> itemStore)
        {
            foreach (var item in TestData.Items)
            {
                await itemStore.AddAsync(item);
            }
        }
    }

    /// <summary>
    /// Extension methods for the <see cref="IOrderStore{TOrder}"/> store
    /// </summary>
    public static class OrderStoreExtensions
    {
        /// <summary>
        /// Populate the product test data
        /// </summary>
        /// <param name="orderStore">
        /// The <see cref="IOrderStore{TOrder}"/> instance
        /// </param>
        public static async void Seed(this IOrderStore<Order> orderStore)
        {
            foreach (var order in TestData.Orders)
            {
                await orderStore.AddAsync(order);
            }
        }
    }
}
