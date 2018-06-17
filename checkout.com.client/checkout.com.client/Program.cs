using System;
using System.Linq;
using System.Net.Http;

namespace checkout.com.client
{
    using Checkout;
    using Checkout.Com.Api.Entities;
    using Checkout.Com.Api.Dto;
    using Microsoft.OData.Client;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        /// <summary>
        /// The api url
        /// </summary>
        private const string url = "http://localhost:51573/api";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to OData client!");

            Run();

            Console.Read();
        }

        private static async void Run()
        {
            // Generated container used to communicate with api
            var container = new Container(new Uri(url));

            // Test data
            var laptop = new Product() { Id = "P001", Name = "MSI Laptop", Brand = "MSI", Price = 1170 };
            var chair = new Product() { Id = "P002", Name = "Bucket Seat", Brand = "Corsair", Price = 554 };
            var order = new Order() { Id = "OR001", CustomerName = "John Nikel" };
            var items1 = new List<Item>()
            {
                new Item(){ Id = "I001", OrderId = "OR001", ProductId= "P001", Quantity = 1 },
                new Item(){ Id = "I002", OrderId = "OR001", ProductId= "P002", Quantity = 2 }
            };
            var items2 = new List<Item>()
            {
                new Item(){ Id = "I001", OrderId = "OR001", ProductId= "P001", Quantity = 1 }
            };
            var billing = new Billing() { CreditCardNumber = "00140562240", CCV = "337" };


            await AddProduct(container, laptop);

            await AddProduct(container, chair);

            await ListProduct(container);

            await CreateOrder(container, order);

            await AddItemsToOrder(container, "OR001", items1);

            await ListOrder(container);

            await RemoveItemsFromOrder(container, "OR001", items2);

            await ListOrder(container);

            await ChangeQuantity(container, "I002", 3);

            await ListOrder(container);

            await ClearOrder(container, "OR001");

            await ListOrder(container);

            await ProcessOrder(container, "OR001", billing);
        }

        /// <summary>
        /// Add a product to the api - POST /Product
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="product">
        /// The <see cref="Product"/> to send
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task AddProduct(Container container, Product product)
        {
            Console.WriteLine("Adding a new product...");

            container.AddToProduct(product);
            var serviceResponse = await container.SaveChangesAsync();

            PrintResponse(serviceResponse.FirstOrDefault());

            Console.WriteLine();
        }

        /// <summary>
        /// Retrieve all products from the api - GET /Product
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task ListProduct(Container container)
        {
            Console.WriteLine("List of Products");

            var products = await container.Product.ExecuteAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"Product - Id: {product.Id} Name: {product.Name} Brand: {product.Brand} Price: {product.Price}");
            }

            Console.WriteLine("-------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Create an order - POST /Order
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="order">
        /// The <see cref="Order"/> to create
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task CreateOrder(Container container, Order order)
        {
            Console.WriteLine("Creating a new order...");

            container.AddToOrder(order);

            var serviceResponse = await container.SaveChangesAsync();

            PrintResponse(serviceResponse.FirstOrDefault());

            Console.WriteLine();
        }

        /// <summary>
        /// Retrieve all orders - GET /Order
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task ListOrder(Container container)
        {
            Console.WriteLine("List of Orders");

            var orders = await container.Order.ExecuteAsync();

            foreach (var order in orders)
            {
                Console.WriteLine($"Order - Id: {order.Id} Customer: {order.CustomerName}");

                var keys = new Dictionary<string, object>();

                var items = (await container.Item.ExecuteAsync()).Where(i => i.OrderId == order.Id);

                foreach (var item in items)
                {
                    Console.WriteLine($"Item - Product Id: {item.ProductId} Quantity: {item.Quantity}");
                }
            }

            Console.WriteLine("-------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Add items to an order - POST /Order({id})/Checkout.AddItems
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="orderId">
        /// The id of the order
        /// </param>
        /// <param name="items">
        /// The list of <see cref="Item"/> to be added
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task AddItemsToOrder(Container container, string orderId, List<Item> items)
        {
            Console.WriteLine("Adding items to order...");

            var serviceResponse = await container.Order.ByKey(orderId).AddItems(items).ExecuteAsync();

            PrintResponse(serviceResponse);

            Console.WriteLine();
        }

        /// <summary>
        /// Remove items from an order - POST /Order({id})/Checkout.RemoveItems
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="orderId">
        /// The id of the order
        /// </param>
        /// <param name="items">
        /// The list of <see cref="Item"/> to remove
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task RemoveItemsFromOrder(Container container, string orderId, List<Item> items)
        {
            Console.WriteLine("Removing items from order...");

            var serviceResponse = await container.Order.ByKey(orderId).RemoveItems(items).ExecuteAsync();

            PrintResponse(serviceResponse);

            Console.WriteLine();
        }

        /// <summary>
        /// Clear an order - POST /Order({id})/Checkout.Clear
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="orderId">
        /// The id of the order  to clear
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task ClearOrder(Container container, string orderId)
        {
            Console.WriteLine("Clearing order...");

            var serviceResponse = await container.Order.ByKey(orderId).Clear(false).ExecuteAsync();

            PrintResponse(serviceResponse);

            Console.WriteLine();
        }

        /// <summary>
        /// Change quantity of an item - PATCH/PUT /Item({id})
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="itemId">
        /// The id of the item
        /// </param>
        /// <param name="quantity">
        /// The new quantity
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task ChangeQuantity(Container container, string itemId, int quantity)
        {
            Console.WriteLine("Changing item quantity..");

            var item = await container.Item.ByKey(itemId).GetValueAsync();

            item.Quantity = quantity;

            container.UpdateObject(item);

            var serviceResponse = await container.SaveChangesAsync();

            PrintResponse(serviceResponse.FirstOrDefault());

            Console.WriteLine();
        }

        /// <summary>
        /// Process an order
        /// </summary>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="orderId">
        /// The id of the order  to process
        /// </param>
        /// /// <param name="billing">
        /// The <see cref="Billing"/> information
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        private static async Task ProcessOrder(Container container, string orderId, Billing billing)
        {
            Console.WriteLine("Processing order...");

            var serviceResponse = await container.Order.ByKey(orderId).Process(billing).ExecuteAsync();

            PrintResponse(serviceResponse);

            Console.WriteLine();
        }

        /// <summary>
        /// Print response status
        /// </summary>
        /// <param name="response"></param>
        private static void PrintResponse(OperationResponse response)
        {
            Console.WriteLine($"Response Code: {response.StatusCode}");

            if (response.Error != null)
            {
                Console.WriteLine($"Error: {response.Error}");
            }
        }
    }
}
