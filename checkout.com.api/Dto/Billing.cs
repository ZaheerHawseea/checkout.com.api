using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.Dto
{
    /// <summary>
    /// The billing data transfer object 
    /// </summary>
    public class Billing
    {
        /// <summary>
        /// Gets or sets the credit card number
        /// </summary>
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the ccv number
        /// </summary>
        public string CCV { get; set; }
    }
}
