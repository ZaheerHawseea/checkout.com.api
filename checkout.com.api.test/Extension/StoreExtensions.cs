using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using checkout.com.api.test.Fixture;

namespace checkout.com.api.test.Extension
{
    public static class StoreExtensions
    {
        public static async void SeedProducts(this IProductStore<Product> productStore)
        {
            foreach (var product in TestData.Products)
            {
                await productStore.AddAsync(product);
            }
        }

        public static async void SeedItems(this IItemStore<Item> itemStore)
        {
            foreach (var item in TestData.Items)
            {
                await itemStore.AddAsync(item);
            }
        }

        public static async void SeedOrders(this IOrderStore<Order> orderStore)
        {
            foreach (var order in TestData.Orders)
            {
                await orderStore.AddAsync(order);
            }
        }
    }
}
