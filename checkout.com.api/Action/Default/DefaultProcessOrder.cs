using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Dto;
using checkout.com.api.Entities;

namespace checkout.com.api.Action.Default
{
    /// <summary>
    /// The default implementation of the process order action
    /// </summary>
    public class DefaultProcessOrder : IProcessOrder
    {
        /// <summary>
        /// Execute the default process order action
        /// </summary>
        /// <param name="order">
        /// The <see cref="Order"/> entity
        /// </param>
        /// <param name="billing">
        /// The <see cref="Billing"/> dtp
        /// </param>
        /// <returns>
        /// Asynchronous <see cref="Task"/> operation of the action
        /// </returns>
        public Task ExecuteAsync(Order order, Billing billing)
        {
            // TODO: Assumption that the logic for order processing will be provided as a separate nuget package/api and the logics can be implemented here.
            return Task.FromResult(true);
        }
    }
}
