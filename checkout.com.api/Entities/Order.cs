using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    /// <summary>
    /// The order entity
    /// </summary>
    public class Order : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the customer name
        /// </summary>
        [MaxLength(50)]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the created date of the order
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the order items
        /// </summary>
        public List<Item> Items { get; set; }
    }
}