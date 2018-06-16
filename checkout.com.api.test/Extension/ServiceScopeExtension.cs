using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace checkout.com.api.test.Extension
{
    /// <summary>
    /// Extension methods for <see cref="IServiceScope"/>
    /// </summary>
    public static class ServiceScopeExtension
    {
        /// <summary>
        /// Configures the test services and populate test data
        /// </summary>
        /// <param name="scope">
        /// The <see cref="IServiceScope"/> instance
        /// </param>
        public static void ConfigureTest(this IServiceScope scope)
        {
            // Retrieve the depedancies from the di container
            var productStore = scope.ServiceProvider.GetService<IProductStore<Product>>();
            var itemStore = scope.ServiceProvider.GetService<IItemStore<Item>>();
            var orderStore = scope.ServiceProvider.GetService<IOrderStore<Order>>();

            // Populate test data
            productStore.Seed();
            itemStore.Seed();
            orderStore.Seed();
        }
    }
}
