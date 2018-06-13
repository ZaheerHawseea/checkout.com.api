using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;

namespace checkout.com.api.Action.Default
{
    public class DefaultRemoveItemsFromOrder : IRemoveItemsFromOrder
    {
        private readonly IItemStore<Item> itemStore;

        public DefaultRemoveItemsFromOrder(IItemStore<Item> itemStore)
        {
            this.itemStore = itemStore;
        }

        public async Task ExecuteAsync(Order order, IList<Item> items)
        {
            foreach (var item in items)
            {
                if (item.OrderId == order.Id)
                { 
                    await itemStore.DeleteAsync(item.Id);
                }
            }
        }
    }
}
