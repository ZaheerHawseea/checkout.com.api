using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    public class Item : IEntity
    {
        public string Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
