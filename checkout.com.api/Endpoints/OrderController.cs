using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public OrderController(IOrderStore<Order> orderStore)
        {
            this.orderStore = orderStore;
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
    }
}
