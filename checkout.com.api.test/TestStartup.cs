using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Configuration;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using checkout.com.api.test.Client;
using checkout.com.api.test.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace checkout.com.api.test
{
    public class TestStartup : Microsoft.AspNetCore.Hosting.StartupBase
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            app.UseCheckoutService("api");

            // Now seed the database
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ConfigureTest();
            }
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddCheckoutServices();
        }
    }
}
