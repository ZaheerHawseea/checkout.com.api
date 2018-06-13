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
    public class ProcessOrderController : ODataController
    {
        private readonly IProcessOrder processOrder;
        private readonly IOrderStore<Order> orderStore;

        public ProcessOrderController(IProcessOrder processOrder, IOrderStore<Order> orderStore)
        {
            this.processOrder = processOrder;
            this.orderStore = orderStore;
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
