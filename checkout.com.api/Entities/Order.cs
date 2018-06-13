using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}