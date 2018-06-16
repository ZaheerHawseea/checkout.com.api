using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    /// <summary>
    /// The product entity
    /// </summary>
    public class Product : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the brand
        /// </summary>
        [MaxLength(30)]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal? Price { get; set; }
    }
}
