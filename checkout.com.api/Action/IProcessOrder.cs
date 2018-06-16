using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Dto;
using checkout.com.api.Entities;

namespace checkout.com.api.Action
{
    /// <summary>
    /// The interface of the process order action
    /// </summary>
    public interface IProcessOrder
    {
        /// <summary>
        /// Execute the process order action
        /// </summary>
        /// <param name="order">
        /// The <see cref="Order"/> entity
        /// </param>
        /// <param name="billing">
        /// The <see cref="Billing"/> dto
        /// </param>
        /// <returns>
        /// Asynchronous <see cref="Task"/> operation of the action
        /// </returns>
        Task ExecuteAsync(Order order, Billing billing);
    }
}