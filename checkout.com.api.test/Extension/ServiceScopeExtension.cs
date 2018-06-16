using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace checkout.com.api.test.Extension
{
    public static class ServiceScopeExtension
    {
        public static void ConfigureTest(this IServiceScope scope)
        {
            var productStore = scope.ServiceProvider.GetService<IProductStore<Product>>();
            var itemStore = scope.ServiceProvider.GetService<IItemStore<Item>>();
            var orderStore = scope.ServiceProvider.GetService<IOrderStore<Order>>();

            productStore.SeedProducts();
            itemStore.SeedItems();
            orderStore.SeedOrders();
        }
    }
}
