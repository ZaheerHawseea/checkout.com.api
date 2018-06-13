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
    public class DataModelBuilder : IModelBuilder
    {
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Product>(nameof(Product));
            builder.EntitySet<Item>(nameof(Item));
            builder.EntitySet<Order>(nameof(Order));

            builder.Namespace = Constants.Namespace;
            builder.EntityType<Order>()
                .Action(Constants.Actions.ProcessOrder)
                .Parameter<Billing>(Constants.Actions.Parameters.Billing);

            builder.EntityType<Order>()
                .Action(Constants.Actions.AddItemsToOrder)
                .Parameter<List<Item>>(Constants.Actions.Parameters.Items);

            builder.EntityType<Order>()
                .Action(Constants.Actions.RemoveItemFromOrder)
                .Parameter<List<Item>>(Constants.Actions.Parameters.Items);

            builder.EntityType<Order>()
                .Action(Constants.Actions.ClearOrder)
                .Parameter<bool>(Constants.Actions.Parameters.Delete);

            return builder.GetEdmModel();
        }
    }
}