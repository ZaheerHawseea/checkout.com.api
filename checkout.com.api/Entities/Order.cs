using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    public class Order : IEntity
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<Item> Items { get; set; }
    }
}