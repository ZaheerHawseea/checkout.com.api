﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using FluentAssertions;
using checkout.com.api.Entities;
using checkout.com.api.Stores.Default;
using checkout.com.api.Stores;
using checkout.com.api.test.Fixture;

namespace checkout.com.api.test.Store
{
    /// <summary>
    /// Class containing the tests of the product store
    /// </summary>
    public class ProductStoreTests : IClassFixture<ProductStoreFixture>
    {
        /// <summary>
        /// The <see cref="IProductStore{TProduct}"/> dependancy
        /// </summary>
        private readonly IProductStore<Product> ProductStore;

        /// <summary>
        /// Initialise a new instance of <see cref="ProductStoreTests"/>
        /// </summary>
        /// <param name="fixture">
        /// The <see cref="ProductStoreFixture"/> dependancy
        /// </param>
        public ProductStoreTests(ProductStoreFixture fixture)
        {
            ProductStore = fixture.Store;
        }

        /// <summary>
        /// Test whether a product is added
        /// </summary>
        [Fact]
        public async void ProductShouldBeAdded()
        {
            // Arrange
            var product = new Product() { Name = "Asus Rog Motherboard", Brand = "Asus", Price = 530 };

            // Act
            var productReturned = await ProductStore.AddAsync(product);

            // Assert
            ProductStore.Count().Result.Should().BeGreaterThan(0);
            productReturned.Name.Should().Be(product.Name);
            productReturned.Brand.Should().Be(product.Brand);
            productReturned.Price.Should().Be(product.Price);
        }

        /// <summary>
        /// Test wether all products are retrieved
        /// </summary>
        [Fact]
        public async void ProductsShouldBeListed()
        {
            // Act
            var products = await ProductStore.FindAllAsync();

            // Assert
            products.Count().Should().BeGreaterThan(0);
        }

        /// <summary>
        /// Test whether a specific product is retrieved
        /// </summary>
        [Fact]
        public async void ProductByIdShouldBeReturned()
        {
            // Arrange
            var product = new Product() { Id = "P003", Name = "MSI GeForce 1080Ti", Brand = "MSI", Price = 664 };

            // Act
            var productReturned = await ProductStore.FindByIdAsync(product.Id);

            // Assert
            productReturned.Should().NotBeNull();
            productReturned.Id.Should().NotBeNullOrWhiteSpace();
            productReturned.Name.Should().Be(product.Name);
            productReturned.Brand.Should().Be(product.Brand);
            productReturned.Price.Should().Be(product.Price);
        }

        /// <summary>
        /// Test whether a product is updated
        /// </summary>
        [Fact]
        public async void ProductShouldBeUpdated()
        {
            // Arrange
            var product = new Product() { Id = "P002", Name = "Intel Core i7 8th Gen", Brand = "Intel", Price = 478 };

            // Act
            var productReturned = await ProductStore.UpdateAsync(product.Id, product);

            // Assert
            productReturned.Id.Should().Be(product.Id);
            productReturned.Name.Should().Be(product.Name);
            productReturned.Brand.Should().Be(product.Brand);
            productReturned.Price.Should().Be(product.Price);
        }

        /// <summary>
        /// Test wether a product is deleted
        /// </summary>
        [Fact]
        public async void ProductShouldBeDeleted()
        {
            // Act
            var result = await ProductStore.DeleteAsync("P001");

            // Assert
            result.Should().Be(true);
        }
    }
}
