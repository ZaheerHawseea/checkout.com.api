﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.DependencyInjection;
using checkout.com.api.Stores;
using checkout.com.api.Entities;
using checkout.com.api.Stores.Default;
using checkout.com.api.Configuration;
using checkout.com.api.Services;
using checkout.com.api.Services.Default;

namespace checkout.com.api
{
    public class Startup
    {
        // Configure services to the di container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCheckoutServices();
        }

        // Configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app)
        {
            app.UseCheckoutService("api");
        }
    }
}