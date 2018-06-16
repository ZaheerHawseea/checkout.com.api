using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    /// <summary>
    /// The item entity
    /// </summary>
    public class Item : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        [Key]
        public string Id { get; set; }        

        /// <summary>
        /// Gets or sets the order id
        /// </summary>
        [ForeignKey("Order")]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the product id
        /// </summary>
        [ForeignKey("Product")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the order
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}