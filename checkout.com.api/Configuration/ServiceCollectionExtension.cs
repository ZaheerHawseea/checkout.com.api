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
using checkout.com.api.FilterAttributes;
using checkout.com.api.Action;
using checkout.com.api.Action.Default;

namespace checkout.com.api.Configuration
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add the checkout service depedencies
        /// </summary>
        /// <param name="services">
        /// The di container
        /// </param>
        public static void AddCheckoutServices(this IServiceCollection services)
        {
            // Add odata services
            services.AddOData();

            // Add mvc services with action filters
            services.AddMvc(options => {
                options.Filters.Add(new ActionValidationAttribute());
            })
                    .AddXmlDataContractSerializerFormatters(); // Enable application/xml formatter

            // Register depedencies with the di container
            services.AddTransient<IProductStore<Product>, InMemoryProductStore>();
            services.AddTransient<IItemStore<Item>, InMemoryItemStore>();
            services.AddTransient<IOrderStore<Order>, InMemoryOrderStore>();
            services.AddTransient<IModelBuilder, DataModelBuilder>();
            services.AddTransient<IProcessOrder, DefaultProcessOrder>();
            services.AddTransient<IAddItemsToOrder, DefaultAddItemsToOrder>();
            services.AddTransient<IRemoveItemsFromOrder, DefaultRemoveItemsFromOrder>();
            services.AddTransient<IClearOrder, DefaultClearOrder>();
        }
    }
}