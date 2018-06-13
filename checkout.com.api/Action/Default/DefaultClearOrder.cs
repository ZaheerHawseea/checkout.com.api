using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;

namespace checkout.com.api.Action.Default
{
    public class DefaultClearOrder : IClearOrder
    {
        private readonly IItemStore<Item> itemStore;
        private readonly IOrderStore<Order> orderStore;

        public DefaultClearOrder(IOrderStore<Order> orderStore, IItemStore<Item> itemStore)
        {
            this.orderStore = orderStore;
            this.itemStore = itemStore;
        }

        public async Task ExecuteAsync(Order order, bool delete)
        {
            foreach (var item in order.Items)
            {
                await itemStore.DeleteAsync(item.Id);
            }

            if (delete)
            {
                await orderStore.DeleteAsync(order.Id);
            }
        }
    }
}
