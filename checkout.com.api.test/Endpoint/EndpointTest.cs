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
    /// <summary>
    /// Integration tests for the checkout service
    /// </summary>
    public class EndpointTest :
        IClassFixture<TestService>,
        IClassFixture<RestClient>
    {
        /// <summary>
        /// The <see cref="TestService"/>
        /// </summary>
        private readonly TestService service;

        /// <summary>
        /// The <see cref="RestClient"/>
        /// </summary>
        private readonly RestClient client;

        /// <summary>
        /// Base url of the api
        /// </summary>
        private const string url = "/api";

        /// <summary>
        /// Initialise a new instance of <see cref="EndpointTest"/>
        /// </summary>
        /// <param name="service">
        /// The <see cref="TestService"/> fixture
        /// </param>
        /// <param name="client">
        /// The <see cref="RestClient"/> fixture
        /// </param>
        public EndpointTest(TestService service, RestClient client)
        {
            this.service = service;
            this.client = client;
        }

        /// <summary>
        /// Endpoint test - GET /Product
        /// </summary>
        [Fact]
        public async void GetProductTest()
        {
            // Act
            var response = await client.GetAsync(service.GetClient(), $"{url}/Product");

            // Assert
            var result = await response.Content.ReadAsAsync<EntityResponse<Product>>();

            response.IsSuccessStatusCode.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Count().Should().BeGreaterThan(0);
        }

        /// <summary>
        /// Endpoint test - POST /Product
        /// </summary>
        [Fact]
        public async void CreateProductTest()
        {
            // Arrange
            var product = new Product() { Name = "Asus Rog Motherboard", Brand = "Price", Price = 350 };

            // Act
            var response = await client.PostAsync<Product>(service.GetClient(), $"{url}/Product", product);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        /// <summary>
        /// Endpoint test - GET /Order
        /// </summary>
        [Fact]
        public async void GetOrderTest()
        {
            // Act
            var response = await client.GetAsync(service.GetClient(), $"{url}/Order");

            // Assert
            var result = await response.Content.ReadAsAsync<EntityResponse<Order>>();

            response.IsSuccessStatusCode.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Count().Should().BeGreaterThan(0);
        }

        /// <summary>
        /// Endpoint test - POST /Order
        /// </summary>
        [Fact]
        public async void CreateOrderTest()
        {
            // Arrange
            var order = new Order() { CustomerName = "James Cameron" };

            // Act
            var response = await client.PostAsync<Order>(service.GetClient(), $"{url}/Order", order);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        /// <summary>
        /// Endpoint test - POST /Order({id})/Checkout.AddItems
        /// </summary>
        [Fact]
        public async void AddItemsToOrderTest()
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

        /// <summary>
        /// Endpoint test - POST /Order({id})/Checkout.RemoveItems
        /// </summary>
        [Fact]
        public async void RemoveItemsToOrderTest()
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

        /// <summary>
        /// Endpoint test - POST /Order({id})/Checkout.Clear
        /// </summary>
        [Fact]
        public async void ClearOrderTest()
        {
            // Arrange
            var content = new ClearOrderRequest() { Delete = false };

            // Act
            var response = await client.PostAsync(service.GetClient(), $"{url}/Order('OR003')/Checkout.Clear", content);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        /// <summary>
        /// Endpoint test - POST /Order({id})/Checkout.Process
        /// </summary>
        [Fact]
        public async void ProcessOrderTest()
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

        /// <summary>
        /// Endpoint test - PATCH /Item({id})
        /// </summary>
        [Fact]
        public async void ChangeQuantityTest()
        {
            // Arrange
            var item = new Item() { Id = "I001", Quantity = 5 };

            // Act
            var response = await client.PatchAsync(service.GetClient(), $"{url}/Item('{item.Id}')", item);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
