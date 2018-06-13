using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api
{
    public static class Constants
    {
        public static class Actions
        {
            public const string ProcessOrder = "ProcessOrder";
        }

        public static class ODataRoutes
        {
            public const string ProductById = "Product({id})";
            public const string ItemById = "Item({id})";
            public const string OrderById = "Order({id})";
            public const string ProcessOrder = OrderById + "/Process";
        }
    }
}
