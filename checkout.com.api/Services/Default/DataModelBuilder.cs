using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using checkout.com.api.Entities;
using checkout.com.api.Dto;

namespace checkout.com.api.Services.Default
{
    /// <summary>
    /// Default implementation of <see cref="IModelBuilder"/>
    /// </summary>
    public class DataModelBuilder : IModelBuilder
    {
        /// <summary>
        /// Retrieve the entity data model for odata
        /// </summary>
        /// <param name="serviceProvider">
        /// The service object that contain the assemblies
        /// </param>
        /// <returns>
        /// The entity data model
        /// </returns>
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.Namespace = Constants.Namespace;

            // Register odata entities
            builder.EntitySet<Product>(nameof(Product));
            builder.EntitySet<Item>(nameof(Item));
            builder.EntitySet<Order>(nameof(Order));

            // Register odata actions
            builder.EntityType<Order>()
                .Action(Constants.Actions.ProcessOrder)
                .Parameter<Billing>(Constants.Actions.Parameters.Billing);

            builder.EntityType<Order>()
                .Action(Constants.Actions.AddItemsToOrder)
                .CollectionParameter<Item>(Constants.Actions.Parameters.Items);

            builder.EntityType<Order>()
                .Action(Constants.Actions.RemoveItemFromOrder)
                .CollectionParameter<Item>(Constants.Actions.Parameters.Items);

            builder.EntityType<Order>()
                .Action(Constants.Actions.ClearOrder)
                .Parameter<bool>(Constants.Actions.Parameters.Delete);

            // Enable odata query
            builder.EntityType<Item>().Count().Filter().OrderBy().Expand().Select();

            return builder.GetEdmModel();
        }
    }
}