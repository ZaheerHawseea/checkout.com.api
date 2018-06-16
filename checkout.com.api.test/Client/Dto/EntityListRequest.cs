using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.test.Client.Dto
{
    /// <summary>
    /// The entity list used in requests
    /// </summary>
    public class EntityListRequest<T>
    {
        public List<T> Items { get; set; }
    }
}
