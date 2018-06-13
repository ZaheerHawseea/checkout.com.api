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
    public class ItemController : ODataController
    {
        private readonly IItemStore<Item> itemStore;

        public ItemController(IItemStore<Item> itemStore)
        {
            this.itemStore = itemStore;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await itemStore.FindAllAsync());
        }

        [EnableQuery]
        [ODataRoute(Constants.ODataRoutes.ItemById)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await itemStore.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            return Created(await itemStore.AddAsync(item));
        }

        [HttpPut]
        [ODataRoute(Constants.ODataRoutes.ItemById)]
        public async Task<IActionResult> Put(string id, [FromBody] Item item)
        {
            return Updated(await itemStore.UpdateAsync(id, item));
        }

        [HttpDelete]
        [ODataRoute(Constants.ODataRoutes.ItemById)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await itemStore.DeleteAsync(id));
        }
    }
}
