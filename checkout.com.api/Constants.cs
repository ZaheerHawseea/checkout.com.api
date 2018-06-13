using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api
{
    public static class Constants
    {
        public const string Namespace = "Checkout";

        public static class Actions
        {
            public const string ProcessOrder = "Process";
            public const string AddItemsToOrder = "AddItems";
            public const string RemoveItemFromOrder = "RemoveItems";
            public const string ClearOrder = "Clear";

            public static class Parameters
            {
                public const string Billing = "Billing";
                public const string Items = "Items";
                public const string Delete = "Delete";
            }
        }

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
