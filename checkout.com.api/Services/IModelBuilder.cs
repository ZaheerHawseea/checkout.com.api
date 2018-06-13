using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.Edm;

namespace checkout.com.api.Services
{
    public interface IModelBuilder
    {
        IEdmModel GetEdmModel(IServiceProvider serviceProvider);
    }
}
