using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;

namespace checkout.com.api.Action.Default
{
    /// <summary>
    /// The default implementation of the clear order action
    /// </summary>
    public class DefaultClearOrder : IClearOrder
    {
        /// <summary>
        /// The <see cref="IItemStore{TItem}"/> dependancy
        /// </summary>
        private readonly IItemStore<Item> itemStore;

        /// <summary>
        /// The <see cref="IOrderStore{TOrder}"/> dependancy
        /// </summary>
        private readonly IOrderStore<Order> orderStore;

        /// <summary>
        /// Initialise a new <see cref="DefaultClearOrder"/> instance
        /// </summary>
        /// <param name="orderStore">
        /// The <see cref="IOrderStore{TOrder}"/> dependancy
        /// </param>
        /// <param name="itemStore">
        /// The <see cref="IItemStore{TItem}"/> dependancy
        /// </param>
        public DefaultClearOrder(IOrderStore<Order> orderStore, IItemStore<Item> itemStore)
        {
            this.orderStore = orderStore;
            this.itemStore = itemStore;
        }

        /// <summary>
        /// Execute the default clear order action
        /// </summary>
        /// <param name="order">
        /// The <see cref="Order"/> entity
        /// </param>
        /// <param name="delete">
        /// Whether the order should be deleted
        /// </param>
        /// <returns>
        /// Asynchronous <see cref="Task"/> operation of the action
        /// </returns>
        public async Task ExecuteAsync(Order order, bool delete)
        {
            var itemIds = (await itemStore.FindByOrderIdAsync(order.Id)).Select(i => i.Id).ToList();

            foreach (var id in itemIds)
            {
                await itemStore.DeleteAsync(id);
            }

            if (delete)
            {
                await orderStore.DeleteAsync(order.Id);
            }
        }
    }
}
