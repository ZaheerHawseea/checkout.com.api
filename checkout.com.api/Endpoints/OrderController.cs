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
    public class OrderController : ODataController
    {
        private readonly IOrderStore<Order> orderStore;
        private readonly IProcessOrder processOrder;
        private readonly IAddItemsToOrder addItemsToOrder;
        private readonly IRemoveItemsFromOrder removeItemsFromOrder;
        private readonly IClearOrder clearOrder;

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

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await orderStore.FindAllAsync());
        }

        [EnableQuery]
        [ODataRoute(Constants.ODataRoutes.OrderById)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await orderStore.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            return Created(await orderStore.AddAsync(order));
        }

        [HttpPut]
        [ODataRoute(Constants.ODataRoutes.OrderById)]
        public async Task<IActionResult> Put(string id, [FromBody] Order order)
        {
            return Updated(await orderStore.UpdateAsync(id, order));
        }

        [HttpDelete]
        [ODataRoute(Constants.ODataRoutes.OrderById)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await orderStore.DeleteAsync(id));
        }

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
