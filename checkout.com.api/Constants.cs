using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api
{
    /// <summary>
    /// Default constant values
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The namespace for odata types
        /// </summary>
        public const string Namespace = "Checkout";

        /// <summary>
        /// The constant values for odata actions
        /// </summary>
        public static class Actions
        {
            public const string ProcessOrder = "Process";

            public const string AddItemsToOrder = "AddItems";

            public const string RemoveItemFromOrder = "RemoveItems";

            public const string ClearOrder = "Clear";

            /// <summary>
            /// The constant values for odata action parameters
            /// </summary>
            public static class Parameters
            {
                public const string Billing = "Billing";

                public const string Items = "Items";

                public const string Delete = "Delete";
            }
        }

        /// <summary>
        /// The constant values for odata routes
        /// </summary>
        public static class ODataRoutes
        {
            public const string ProductById = "Product({id})";

            public const string ItemById = "Item({id})";

            public const string OrderById = "Order({id})";

            public const string ProcessOrder = OrderById + "/" + Namespace + "." + Actions.ProcessOrder;

            public const string AddItemsToOrder = OrderById + "/" + Namespace + "." + Actions.AddItemsToOrder;

            public const string RemoveItemFromOrder = OrderById + "/" + Namespace + "." + Actions.RemoveItemFromOrder;

            public const string ClearOrder = OrderById + "/" + Namespace + "." + Actions.ClearOrder;
        }
    }
}
