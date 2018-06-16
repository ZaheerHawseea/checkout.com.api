using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.test.Client.Dto
{
    /// <summary>
    /// The dto used in the clear order request
    /// </summary>
    public class ClearOrderRequest
    {
        public bool? Delete { get; set; }
    }
}
