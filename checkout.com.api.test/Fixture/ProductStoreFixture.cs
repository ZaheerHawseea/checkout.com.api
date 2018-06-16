using checkout.com.api.Entities;
using checkout.com.api.Stores;
using checkout.com.api.Stores.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.test.Fixture
{
    /// <summary>
    /// Fixture class for the product store
    /// </summary>
    public class ProductStoreFixture
    {
        /// <summary>
        /// The <see cref="IProductStore{TProduct}"/> dependancy
        /// </summary>
        public IProductStore<Product> Store { get; private set; }

        /// <summary>
        /// Initialise a new <see cref="ProductStoreFixture"/> instance
        /// </summary>
        public ProductStoreFixture()
        {
            Store = new InMemoryProductStore();

            Seed();
        }

        /// <summary>
        /// Populate test data
        /// </summary>
        private async void Seed()
        {
            foreach (var product in TestData.Products)
            {
                await Store.AddAsync(product);
            }
        }
    }
}
