using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using checkout.com.api;
using System.Net.Http;
using Xunit;
using checkout.com.api.Entities;
using System.Net.Http.Formatting;

namespace checkout.com.api.test.EndpointTest
{
    public class TestService : IClassFixture<WebApplicationFactory<Startup>>
    {
        private static WebApplicationFactory<Startup> factory = null;

        public TestService(WebApplicationFactory<Startup> factory)
        {
            if (TestService.factory == null)
            {
                TestService.factory = factory;
            }
        }

        public HttpClient GetClient()
        {
            return TestService.factory.CreateClient();
        }

        [Fact]
        public async Task CreateProductTest()
        {
            // Arrange
            var client = this.GetClient();
            var product = new Product() { Name = "Asus Rog Motherboard", Brand = "Price", Price = 350 };

            // Act
            var content = new ObjectContent<Product>(product, new JsonMediaTypeFormatter());
            var response = await client.PostAsync("/api/Product", content);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}