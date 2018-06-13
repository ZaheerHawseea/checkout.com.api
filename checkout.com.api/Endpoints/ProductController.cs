using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData.Routing;
using System.Net;

namespace checkout.com.api.Endpoints
{
    public class ProductController : ODataController
    {
        private readonly IProductStore<Product> productStore;

        public ProductController(IProductStore<Product> productStore)
        {
            this.productStore = productStore;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await productStore.FindAllAsync());
        }

        [EnableQuery]
        [ODataRoute(Constants.ODataRoutes.ProductById)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await productStore.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            return Created(await productStore.AddAsync(product));
        }

        [HttpPut]
        [ODataRoute(Constants.ODataRoutes.ProductById)]
        public async Task<IActionResult> Put(string id, [FromBody] Product product)
        {
            return Updated(await productStore.UpdateAsync(id, product));
        }

        [HttpDelete]
        [ODataRoute(Constants.ODataRoutes.ProductById)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await productStore.DeleteAsync(id));
        }
    }
}