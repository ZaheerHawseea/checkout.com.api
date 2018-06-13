using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Http;
using checkout.com.api.Services;

namespace checkout.com.api.Configuration

{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCheckoutService(this IApplicationBuilder app, string prefix)
        {
            if (((IHostingEnvironment) app.ApplicationServices.GetService(typeof(IHostingEnvironment))).IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routeBuilder => 
                            routeBuilder.MapODataServiceRoute("ODataRoutes", prefix, ((IModelBuilder) app.ApplicationServices.GetService(typeof(IModelBuilder))).GetEdmModel(app.ApplicationServices)));

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MVC did not found something!");
            });
        }
    }
}