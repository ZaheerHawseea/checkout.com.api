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
    /// <summary>
    /// Extension methods for <see cref="IApplicationBuilder"/>
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure the checkout service
        /// </summary>
        /// <param name="app">
        /// The asp.net core application builder
        /// </param>
        /// <param name="prefix">
        /// The api url prefix
        /// </param>
        public static void UseCheckoutService(this IApplicationBuilder app, string prefix)
        {
            // Show stack trace in development
            if (((IHostingEnvironment) app.ApplicationServices.GetService(typeof(IHostingEnvironment))).IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Configure odata routes
            app.UseMvc(routeBuilder =>
                routeBuilder.MapODataServiceRoute("ODataRoutes", prefix, ((IModelBuilder)app.ApplicationServices.GetService(typeof(IModelBuilder))).GetEdmModel(app.ApplicationServices)));

            // Default middleware if request is not handled by any controller
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("No matching OData controller found!");
            });
        }
    }
}