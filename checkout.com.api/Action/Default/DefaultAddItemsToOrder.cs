using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;

namespace checkout.com.api.Action.Default
{
    /// <summary>
    /// The default implementation of the add items to order action
    /// </summary>
    public class DefaultAddItemsToOrder : IAddItemsToOrder
    {
        /// <summary>
        /// The <see cref="IItemStore{TItem}"/> store
        /// </summary>
        private readonly IItemStore<Item> itemStore;

        /// <summary>
        /// Initialise a new <see cref="DefaultAddItemsToOrder"/> instance
        /// </summary>
        /// <param name="itemStore">
        /// The item store dependancy
        /// </param>
        public DefaultAddItemsToOrder(IItemStore<Item> itemStore)
        {
            this.itemStore = itemStore;
        }

        /// <summary>
        /// Execute the default add items to order action
        /// </summary>
        /// <param name="order">
        /// The <see cref="Order"/> entity
        /// </param>
        /// <param name="items">
        /// The list of <see cref="Item"/> entity
        /// </param>
        /// <returns>
        /// Asynchronous <see cref="Task"/> operation of the action
        /// </returns>
        public async Task ExecuteAsync(Order order, IList<Item> items)
        {
            foreach (var item in items)
            {
                item.OrderId = order.Id;

                await itemStore.AddAsync(item);
            }
        }
    }
}
