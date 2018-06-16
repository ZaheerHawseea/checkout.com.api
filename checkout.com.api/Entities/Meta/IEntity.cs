using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.Entities.Meta
{
    /// <summary>
    /// The Entity interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or Sets the unique identifier
        /// </summary>
        string Id { get; set; }
    }
}