using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using FluentAssertions;
using checkout.com.api.Entities;
using checkout.com.api.Stores.Default;
using checkout.com.api.Stores;

namespace checkout.com.api.test.StoreTest
{
    public class ProductStoreTests
    {
        private readonly IProductStore<Product> ProductStore;

        public ProductStoreTests()
        {
            ProductStore = new InMemoryProductStore();
        }

        [Fact]
        public async void ProductShouldBeAdded()
        {
            // Arrange
            var product = new Product() { Name = "Asus Rog Motherboard", Brand = "Asus", Price = 530 };

            // Act
            var productReturned = await ProductStore.AddAsync(product);

            // Assert
            ProductStore.Count().Result.Should().Be(1);
            productReturned.Name.Should().Be(product.Name);
            productReturned.Brand.Should().Be(product.Brand);
            productReturned.Price.Should().Be(product.Price);
        }

        [Fact]
        public async void ProductsShouldBeListed()
        {
            // Arrange
            var product = new Product() { Name = "Asus Rog Motherboard", Brand = "Asus", Price = 530 };
            await ProductStore.AddAsync(product);

            // Act
            var products = await ProductStore.FindAllAsync();

            // Assert
            products.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async void ProductByIdShouldBeReturned()
        {
            // Arrange
            var product = new Product() { Name = "Asus Rog Motherboard", Brand = "Asus", Price = 530 };
            await ProductStore.AddAsync(product);

            // Act
            var productReturned = await ProductStore.FindByIdAsync(product.Id);

            // Assert
            productReturned.Should().NotBeNull();
            productReturned.Id.Should().NotBeNullOrWhiteSpace();
            productReturned.Name.Should().Be(product.Name);
            productReturned.Brand.Should().Be(product.Brand);
            productReturned.Price.Should().Be(product.Price);
        }

        [Fact]
        public async void ProductShouldBeUpdated()
        {
            // Arrange
            var product = new Product() { Id = "001", Name = "Asus Rog Motherboard", Brand = "Asus", Price = 530 };
            await ProductStore.AddAsync(product);

            product.Name = "Asus Rog Strix Z370 Motherboard";

            // Act
            var productReturned = await ProductStore.UpdateAsync(product.Id, product);

            // Assert
            productReturned.Id.Should().Be(product.Id);
            productReturned.Name.Should().Be(product.Name);
            productReturned.Brand.Should().Be(product.Brand);
            productReturned.Price.Should().Be(product.Price);
        }

        [Fact]
        public async void ProductShouldBeDeleted()
        {
            // Arrange
            var product = new Product() { Id = "001", Name = "Asus Rog Motherboard", Brand = "Asus", Price = 530 };
            await ProductStore.AddAsync(product);

            // Act
            var result = await ProductStore.DeleteAsync(product.Id);

            // Assert
            result.Should().Be(true);
        }
    }
}
