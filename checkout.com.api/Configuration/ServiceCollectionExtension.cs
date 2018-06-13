﻿using System;
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
    public static class ServiceCollectionExtension
    {
        public static void AddCheckoutServices(this IServiceCollection services)
        {
            services.AddOData();

            services.AddMvc(options => {
                options.Filters.Add(new ActionValidationAttribute());
            })
                    .AddXmlDataContractSerializerFormatters();

            // Register dependancies
            services.AddTransient<IProductStore<Product>, InMemoryProductStore>();
            services.AddTransient<IItemStore<Item>, InMemoryItemStore>();
            services.AddTransient<IOrderStore<Order>, InMemoryOrderStore>();
            services.AddTransient<IModelBuilder, DataModelBuilder>();
            services.AddTransient<IProcessOrder, DefaultProcessOrder>();
        }
    }
}
