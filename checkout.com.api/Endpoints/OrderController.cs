using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Action;
using checkout.com.api.Dto;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace checkout.com.api.Endpoints
{
    /// <summary>
    /// The order controller
    /// </summary>
    public class OrderController : ODataController
    {
        /// <summary>
        /// The order store dependancy
        /// </summary>
        private readonly IOrderStore<Order> orderStore;

        /// <summary>
        /// The process order action dependancy
        /// </summary>
        private readonly IProcessOrder processOrder;

        /// <summary>
        /// The add items to order action dependancy
        /// </summary>
        private readonly IAddItemsToOrder addItemsToOrder;

        /// <summary>
        /// The remove items from order action dependancy
        /// </summary>
        private readonly IRemoveItemsFromOrder removeItemsFromOrder;

        /// <summary>
        /// The clear order action dependancy
        /// </summary>
        private readonly IClearOrder clearOrder;

        /// <summary>
        /// Initialise a new <see cref="OrderController"/> instance
        /// </summary>
        /// <param name="orderStore">
        /// The order store dependancy
        /// </param>
        /// <param name="processOrder">
        /// The process order action dependancy
        /// </param>
        /// <param name="addItemsToOrder">
        /// The add items to order action dependancy
        /// </param>
        /// <param name="removeItemsFromOrder">
        /// The remove items from order action dependancy
        /// </param>
        /// <param name="clearOrder">
        /// The clear order action dependancy
        /// </param>
        public OrderController(IOrderStore<Order> orderStore, 
                               IProcessOrder processOrder, 
                               IAddItemsToOrder addItemsToOrder, 
                               IRemoveItemsFromOrder removeItemsFromOrder, 
                               IClearOrder clearOrder)
        {
            this.orderStore = orderStore;
            this.processOrder = processOrder;
            this.addItemsToOrder = addItemsToOrder;
            this.removeItemsFromOrder = removeItemsFromOrder;
            this.clearOrder = clearOrder;
        }

        /// <summary>
        /// Endpoint to get a queryable list of all orders
        /// </summary>
        /// <returns>
        /// 200 Ok - The list of all orders
        /// </returns>
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await orderStore.FindAllAsync());
        }

        /// <summary>
        /// Endpoint to get an order by id
        /// </summary>
        /// <param name="id">
        /// The id of the order to retrieve
        /// </param>
        /// <returns>
        /// 200 Ok - The retrieved order
        /// </returns>
        [EnableQuery]
        [ODataRoute(Constants.ODataRoutes.OrderById)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await orderStore.FindByIdAsync(id));
        }

        /// <summary>
        /// Endpoint to create a new order
        /// </summary>
        /// <param name="order">
        /// The order to be created
        /// </param>
        /// <returns>
        /// 201 Created - The added order
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            return Created(await orderStore.AddAsync(order));
        }

        /// <summary>
        /// Endpoint to update an order using Put
        /// </summary>
        /// <param name="id">
        /// The id of the order to update
        /// </param>
        /// <param name="order">
        /// The updated order
        /// </param>
        /// <returns>
        /// 204 No Content
        /// </returns>
        [HttpPut]
        [ODataRoute(Constants.ODataRoutes.OrderById)]
        public async Task<IActionResult> Put(string id, [FromBody] Order order)
        {
            return Updated(await orderStore.UpdateAsync(id, order));
        }

        /// <summary>
        /// Endpoint to delete an order
        /// </summary>
        /// <param name="id">
        /// The id of the order to delete
        /// </param>
        /// <returns>
        /// 200 Ok
        /// </returns>
        [HttpDelete]
        [ODataRoute(Constants.ODataRoutes.OrderById)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await orderStore.DeleteAsync(id));
        }

        /// <summary>
        /// Endpoint to process an order
        /// </summary>
        /// <param name="id">
        /// The id of the order
        /// </param>
        /// <param name="parameters">
        /// The odata parameters containing the <see cref="Billing"/> information
        /// </param>
        /// <returns>
        /// 200 Ok
        /// </returns>
        [HttpPost]
        [ODataRoute(Constants.ODataRoutes.ProcessOrder)]
        public async Task<IActionResult> ProcessOrder([FromODataUri] string id, ODataActionParameters parameters)
        {
            var order = await orderStore.FindByIdAsync(id);
            var billing = (Billing) parameters.SingleOrDefault(p => p.Key == Constants.Actions.Parameters.Billing).Value;

            if (order == null || billing == null)
            {
                return BadRequest();
            }

            await processOrder.ExecuteAsync(order, billing);

            return Ok();
        }

        /// <summary>
        /// Endpoint to add items to an order
        /// </summary>
        /// <param name="id">
        /// The id of the order
        /// </param>
        /// <param name="parameters">
        /// The odata parameters containing the list of <see cref="Item"/> to be added
        /// </param>
        /// <returns>
        /// 200 Ok
        /// </returns>
        [HttpPost]
        [ODataRoute(Constants.ODataRoutes.AddItemsToOrder)]
        public async Task<IActionResult> AddItemsToOrder([FromODataUri] string id, ODataActionParameters parameters)
        {
            var order = await orderStore.FindByIdAsync(id);
            var items = (IEnumerable<Item>) parameters.SingleOrDefault(p => p.Key == Constants.Actions.Parameters.Items).Value;

            if (order == null || items == null)
            {
                return BadRequest();
            }

            await addItemsToOrder.ExecuteAsync(order, items.ToList());

            return Ok();
        }

        /// <summary>
        /// Endpoint to remove items from an order
        /// </summary>
        /// <param name="id">
        /// The id of the order
        /// </param>
        /// <param name="parameters">
        /// The odata parameters containing the list of <see cref="Item"/> to be added
        /// </param>
        /// <returns>
        /// 200 Ok
        /// </returns>
        [HttpPost]
        [ODataRoute(Constants.ODataRoutes.RemoveItemFromOrder)]
        public async Task<IActionResult> RemoveItemsFromOrder([FromODataUri] string id, ODataActionParameters parameters)
        {
            var order = await orderStore.FindByIdAsync(id);
            var items = (IEnumerable<Item>)parameters.SingleOrDefault(p => p.Key == Constants.Actions.Parameters.Items).Value;

            if (order == null || items == null)
            {
                return BadRequest();
            }

            await removeItemsFromOrder.ExecuteAsync(order, items.ToList());

            return Ok();
        }

        /// <summary>
        /// Endpoint to clear an order
        /// </summary>
        /// <param name="id">
        /// The id of the order
        /// </param>
        /// <param name="parameters">
        /// The odata parameter containing a <see cref="bool"/> if order needs to be deleted
        /// </param>
        /// <returns>
        /// 200 Ok
        /// </returns>
        [HttpPost]
        [ODataRoute(Constants.ODataRoutes.ClearOrder)]
        public async Task<IActionResult> ClearOrder([FromODataUri] string id, ODataActionParameters parameters)
        {
            var order = await orderStore.FindByIdAsync(id);
            var delete = (bool) parameters.SingleOrDefault(p => p.Key == Constants.Actions.Parameters.Delete).Value;

            if (order == null)
            {
                return BadRequest();
            }

            await clearOrder.ExecuteAsync(order, delete);

            return Ok();
        }
    }
}
