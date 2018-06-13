using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    public class Item : IEntity
    {
        [Key]
        public string Id { get; set; }        

        [ForeignKey("Order")]
        public string OrderId { get; set; }

        [ForeignKey("Product")]
        public string ProductId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}