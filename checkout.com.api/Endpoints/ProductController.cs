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
    /// <summary>
    /// The product controller
    /// </summary>
    public class ProductController : ODataController
    {
        /// <summary>
        /// The product store dependancy
        /// </summary>
        private readonly IProductStore<Product> productStore;

        /// <summary>
        /// Initialise a new <see cref="ProductController"/> instance
        /// </summary>
        /// <param name="productStore">
        /// The product store dependancy
        /// </param>
        public ProductController(IProductStore<Product> productStore)
        {
            this.productStore = productStore;
        }

        /// <summary>
        /// Endpoint to get a queryable list of all products
        /// </summary>
        /// <returns>
        /// 200 Ok - The list of all products
        /// </returns>
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await productStore.FindAllAsync());
        }

        /// <summary>
        /// Endpoint to get a product by id
        /// </summary>
        /// <param name="id">
        /// The id of the product to retrieve
        /// </param>
        /// <returns>
        /// 200 Ok - The retrieved product
        /// </returns>
        [EnableQuery]
        [ODataRoute(Constants.ODataRoutes.ProductById)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await productStore.FindByIdAsync(id));
        }

        /// <summary>
        /// Endpoint to create a new product
        /// </summary>
        /// <param name="product">
        /// The product to be created
        /// </param>
        /// <returns>
        /// 201 Created - The added product
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            return Created(await productStore.AddAsync(product));
        }

        /// <summary>
        /// Endpoint to update a product using Put
        /// </summary>
        /// <param name="id">
        /// The id of the product to update
        /// </param>
        /// <param name="product">
        /// The updated product
        /// </param>
        /// <returns>
        /// 204 No Content
        /// </returns>
        [HttpPut]
        [ODataRoute(Constants.ODataRoutes.ProductById)]
        public async Task<IActionResult> Put(string id, [FromBody] Product product)
        {
            return Updated(await productStore.UpdateAsync(id, product));
        }

        /// <summary>
        /// Endpoint to delete a product
        /// </summary>
        /// <param name="id">
        /// The id of the product to delete
        /// </param>
        /// <returns>
        /// 200 Ok
        /// </returns>
        [HttpDelete]
        [ODataRoute(Constants.ODataRoutes.ProductById)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await productStore.DeleteAsync(id));
        }
    }
}