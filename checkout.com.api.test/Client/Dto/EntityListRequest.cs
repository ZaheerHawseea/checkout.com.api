using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.test.Client.Dto
{
    public class EntityListRequest<T>
    {
        public List<T> Items { get; set; }
    }
}
