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
    /// <summary>
    /// The item controller
    /// </summary>
    public class ItemController : ODataController
    {
        /// <summary>
        /// The item store dependancy
        /// </summary>
        private readonly IItemStore<Item> itemStore;

        /// <summary>
        /// Initialise a new <see cref="ItemController"/> instance
        /// </summary>
        /// <param name="itemStore">
        /// The item store dependancy
        /// </param>
        public ItemController(IItemStore<Item> itemStore)
        {
            this.itemStore = itemStore;
        }

        /// <summary>
        /// Endpoint to get a queryable list of all items
        /// </summary>
        /// <returns>
        /// 200 Ok - The list of all items
        /// </returns>
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await itemStore.FindAllAsync());
        }

        /// <summary>
        /// Endpoint to get an item by id
        /// </summary>
        /// <param name="id">
        /// The id of the item to retrieve
        /// </param>
        /// <returns>
        /// 200 Ok - The retrieved item
        /// </returns>
        [EnableQuery]
        [ODataRoute(Constants.ODataRoutes.ItemById)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await itemStore.FindByIdAsync(id));
        }

        /// <summary>
        /// Endpoint to update an item using Put
        /// </summary>
        /// <param name="id">
        /// The id of the item to update
        /// </param>
        /// <param name="item">
        /// The updated item
        /// </param>
        /// <returns>
        /// 204 No Content
        /// </returns>
        [HttpPut]
        [ODataRoute(Constants.ODataRoutes.ItemById)]
        public async Task<IActionResult> Put(string id, [FromBody] Item item)
        {
            return Updated(await itemStore.UpdateAsync(id, item));
        }

        /// <summary>
        /// Endpoint to update an item using Patch
        /// </summary>
        /// <param name="id">
        /// The id of the item to update
        /// </param>
        /// <param name="deltaItem">
        /// The partial changed item
        /// </param>
        /// <returns>
        /// 204 No Content
        /// </returns>
        [HttpPatch]
        [ODataRoute(Constants.ODataRoutes.ItemById)]
        public async Task<IActionResult> Patch(string id, [FromBody] Delta<Item> deltaItem)
        {
            var item = await itemStore.FindByIdAsync(id);

            deltaItem.Patch(item);

            return Updated(await itemStore.UpdateAsync(id, item));
        }

        /// <summary>
        /// Endpoint to delete an item
        /// </summary>
        /// <param name="id">
        /// The id of the item to delete
        /// </param>
        /// <returns>
        /// 200 Ok
        /// </returns>
        [HttpDelete]
        [ODataRoute(Constants.ODataRoutes.ItemById)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await itemStore.DeleteAsync(id));
        }
    }
}
