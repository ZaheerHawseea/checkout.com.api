using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using checkout.com.api.test.Service;
using checkout.com.api.test.Client;
using checkout.com.api.test.Client.Dto;
using System.Net.Http;
using checkout.com.api.Entities;
using FluentAssertions;
using checkout.com.api.Dto;

namespace checkout.com.api.test.Endpoint
{
    public class EndpointTest :
        IClassFixture<TestService>,
        IClassFixture<RestClient>
    {
        private readonly TestService service;
        private readonly RestClient client;

        private const string url = "/api";

        public EndpointTest(TestService service, RestClient client)
        {
            this.service = service;
            this.client = client;
        }

        [Fact]
        public async Task GetProductTest()
        {
            // Act
            var response = await client.GetAsync(service.GetClient(), $"{url}/Product");

            var result = await response.Content.ReadAsAsync<EntityResponse<Product>>();

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task CreateProductTest()
        {
            // Arrange
            var product = new Product() { Name = "Asus Rog Motherboard", Brand = "Price", Price = 350 };

            // Act
            var response = await client.PostAsync<Product>(service.GetClient(), $"{url}/Product", product);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task GetOrderTest()
        {
            // Act
            var response = await client.GetAsync(service.GetClient(), $"{url}/Order");

            var result = await response.Content.ReadAsAsync<EntityResponse<Order>>();

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task CreateOrderTest()
        {
            // Arrange
            var order = new Order() { CustomerName = "James Cameron" };

            // Act
            var response = await client.PostAsync<Order>(service.GetClient(), $"{url}/Order", order);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task AddItemsToOrderTest()
        {
            // Arrange
            var content = new EntityListRequest<Item>()
            {
                Items = new List<Item>()
                {
                    new Item(){ OrderId = "OR001", ProductId = "P003", Quantity = 1 }
                }
            };

            // Act
            var response = await client.PostAsync(service.GetClient(), $"{url}/Order('OR001')/Checkout.AddItems", content);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task RemoveItemsToOrderTest()
        {
            // Arrange
            var content = new EntityListRequest<Item>()
            {
                Items = new List<Item>()
                {
                    new Item(){ OrderId = "OR002", Id = "I002" }
                }
            };

            // Act
            var response = await client.PostAsync(service.GetClient(), $"{url}/Order('OR002')/Checkout.RemoveItems", content);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task ClearOrderTest()
        {
            // Arrange
            var content = new ClearOrderRequest() { Delete = false };

            // Act
            var response = await client.PostAsync(service.GetClient(), $"{url}/Order('OR003')/Checkout.Clear", content);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task ProcessOrderTest()
        {
            // Arrange
            var content = new ProcessOrderRequest()
            {
                Billing = new Billing()
                {
                    CCV = "337",
                    CreditCardNumber = "0046521005706"
                }
            };

            // Act
            var response = await client.PostAsync(service.GetClient(), $"{url}/Order('OR001')/Checkout.Process", content);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
