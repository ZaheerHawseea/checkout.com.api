using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.DependencyInjection;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using checkout.com.api.Stores.Default;
using checkout.com.api.Services;
using checkout.com.api.Services.Default;

namespace checkout.com.api.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static void AddCheckoutServices(this IServiceCollection services)
        {
            services.AddOData();

            services.AddMvc()
                    .AddXmlDataContractSerializerFormatters();

            // Register dependancies
            services.AddTransient<IProductStore<Product>, InMemoryProductStore>();
            services.AddTransient<IItemStore<Item>, InMemoryItemStore>();
            services.AddTransient<IOrderStore<Order>, InMemoryOrderStore>();
            services.AddTransient<IModelBuilder, DataModelBuilder>();
        }
    }
}
