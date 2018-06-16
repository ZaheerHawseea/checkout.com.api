using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;
using checkout.com.api.Stores;

namespace checkout.com.api.Action.Default
{
    /// <summary>
    /// The default implementation of the remove items from order action
    /// </summary>
    public class DefaultRemoveItemsFromOrder : IRemoveItemsFromOrder
    {
        /// <summary>
        /// The <see cref="IItemStore{TItem}"/> dependancy
        /// </summary>
        private readonly IItemStore<Item> itemStore;

        /// <summary>
        /// Initialise a new instance of <see cref="DefaultRemoveItemsFromOrder"/>
        /// </summary>
        /// <param name="itemStore">
        /// The <see cref="IItemStore{TItem}"/> dependancy
        /// </param>
        public DefaultRemoveItemsFromOrder(IItemStore<Item> itemStore)
        {
            this.itemStore = itemStore;
        }

        /// <summary>
        /// Executes the default remove items from order action
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
                if (item.OrderId == order.Id)
                { 
                    await itemStore.DeleteAsync(item.Id);
                }
            }
        }
    }
}
