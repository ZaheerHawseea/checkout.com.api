using checkout.com.api.Entities;
using checkout.com.api.Stores;
using checkout.com.api.Stores.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkout.com.api.test.Fixture
{
    public class ProductStoreFixture
    {
        public IProductStore<Product> Store { get; private set; }

        public ProductStoreFixture()
        {
            Store = new InMemoryProductStore();

            Seed();
        }

        private async void Seed()
        {
            foreach (var product in TestData.Products)
            {
                await Store.AddAsync(product);
            }
        }
    }
}
