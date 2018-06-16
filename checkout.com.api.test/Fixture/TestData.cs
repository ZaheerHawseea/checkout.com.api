using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.test.Fixture
{
    /// <summary>
    /// Initial set of test data
    /// </summary>
    public static class TestData
    {
        /// <summary>
        /// List of <see cref="Product"/> entity
        /// </summary>
        public static IList<Product> Products = new List<Product>()
        {
            new Product(){ Id = "P001", Name = "Asus Rog Strix Motherboard", Brand = "Asus", Price = 350 },
            new Product(){ Id = "P002", Name = "Intel Core i7 8600", Brand = "Asus", Price = 478 },
            new Product(){ Id = "P003", Name = "MSI GeForce 1080Ti", Brand = "MSI", Price = 664 }
        };

        /// <summary>
        /// List of <see cref="Item"/> entity
        /// </summary>
        public static IList<Item> Items = new List<Item>()
        {
            new Item(){ Id = "I001", OrderId = "OR001", ProductId = "P001", Quantity = 1 },
            new Item(){ Id = "I002", OrderId = "OR001", ProductId = "P002", Quantity = 2 },
            new Item(){ Id = "I003", OrderId = "OR002", ProductId = "P003", Quantity = 1 },
            new Item(){ Id = "I004", OrderId = "OR003", ProductId = "P002", Quantity = 3 }
        };

        /// <summary>
        /// List of <see cref="Order"/> entity
        /// </summary>
        public static IList<Order> Orders = new List<Order>()
        {
            new Order(){  Id = "OR001", CustomerName = "Zaheer Hawseea" },
            new Order(){  Id = "OR002", CustomerName = "James Cameron" },
            new Order(){  Id = "OR003", CustomerName = "Eliot Paul" }
        };
    }
}
