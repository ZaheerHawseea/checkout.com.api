using checkout.com.api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.test.Client.Dto
{
    /// <summary>
    /// The dto used for process order request
    /// </summary>
    public class ProcessOrderRequest
    {
        public Billing Billing { get; set; }
    }
}
