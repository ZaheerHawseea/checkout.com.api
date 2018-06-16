using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Action
{
    /// <summary>
    /// The interface of the remove items from order action
    /// </summary>
    public interface IRemoveItemsFromOrder
    {
        /// <summary>
        /// Execute the remove items from order action
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
        Task ExecuteAsync(Order order, IList<Item> items);
    }
}