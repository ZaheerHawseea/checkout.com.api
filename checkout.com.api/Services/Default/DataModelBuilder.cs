using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using checkout.com.api.Entities;

namespace checkout.com.api.Services.Default
{
    public class DataModelBuilder : IModelBuilder
    {
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            // TODO : Use reflection to get all entity sets

            builder.EntitySet<Product>(nameof(Product));
            builder.EntitySet<Item>(nameof(Item));
            builder.EntitySet<Order>(nameof(Order));

            builder.Action(Constants.Actions.ProcessOrder);

            return builder.GetEdmModel();
        }
    }
}