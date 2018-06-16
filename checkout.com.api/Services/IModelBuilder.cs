using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OData.Edm;

namespace checkout.com.api.Services
{
    /// <summary>
    /// The interface for building the EdmModel used by OData
    /// </summary>
    public interface IModelBuilder
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
        IEdmModel GetEdmModel(IServiceProvider serviceProvider);
    }
}
