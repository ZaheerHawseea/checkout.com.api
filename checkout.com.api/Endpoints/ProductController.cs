using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using checkout.com.api.Entities;
using checkout.com.api.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData.Routing;

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
        public async Task<IQueryable<Product>> Get()
        {
            return await productStore.FindAllAsync();
        }

        [EnableQuery]
        [ODataRoute("Product({Id})")]
        public async Task<Product> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async void Post([FromBody] Product product)
        {
            await productStore.AddAsync(product);
        }
    }
}