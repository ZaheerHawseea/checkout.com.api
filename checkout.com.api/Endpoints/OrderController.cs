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

        public OrderController(IOrderStore<Order> orderStore, IProcessOrder processOrder)
        {
            this.orderStore = orderStore;
            this.processOrder = processOrder;
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
            return Ok(await orderStore.FindById(id));
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
        public async Task<IActionResult> ProcessOrder(string id, [FromBody] Billing billing)
        {
            var order = await orderStore.FindById(id);

            if (order == null)
            {
                return BadRequest();
            }

            await processOrder.ExecuteAsync(order, billing);

            return Ok();
        }
    }
}
