using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Entities
{
    public class Product : IEntity
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Brand { get; set; }

        public decimal? Price { get; set; }
    }
}
