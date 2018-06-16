using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Action
{
    /// <summary>
    /// The interface of the clear order action
    /// </summary>
    public interface IClearOrder
    {
        /// <summary>
        /// Execute the clear order action
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
        Task ExecuteAsync(Order order, bool delete);
    }
}
