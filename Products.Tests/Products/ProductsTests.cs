using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Products.API.Controllers;
using Products.API.Data.Repository;
using Products.API.DTO;
using Products.API.Models;
using Products.API.Profiles;

namespace Products.Tests.Products
{
    public class ProductsTests
    {
        private readonly Mock<IRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly ProductController _controller;

        public ProductsTests()
        {
            _repositoryMock = new Mock<IRepository>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductsProfile());
            });
            _mapper = configuration.CreateMapper();

            _controller = new ProductController(_repositoryMock.Object, _mapper);
        }

        // Test methods for the ProductController
        // 1. Test GetAllProducts
        // 2. Test GetProductById
        // 3. Test AddProduct
        // 4. Test UpdateProduct
        // 5. Test DeleteProduct
        // Example test method for GetAllProducts
        [Fact(DisplayName = "Given the repository contains two products, When the controller's Get method is called, Then it should return an OkObjectResult containing a list with two products")]
        public async Task GetAllProducts_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var products = new Product[]
            {
            new Product { Id = 1, Name = "Product 1" },
            new Product { Id = 2, Name = "Product 2" }
            };

            _repositoryMock.Setup(repo => repo.GetAllProducts()).ReturnsAsync(products);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Product[]>(okResult.Value);
            Assert.Equal(2, returnValue.Length);
        }

        [Fact(DisplayName = "Given a product ID that does not exist in the repository, When the GetProductById endpoint is called, Then it should return a NotFound result")]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            int productId = 1;
            _repositoryMock.Setup(repo => repo.GetProductById(productId)).ReturnsAsync((Product)null);

            // Act
            var result = await _controller.Get(productId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact(DisplayName = "Given a product ID that exists in the repository, When the GetProductById endpoint is called, Then it should return an Ok result with the corresponding product")]
        public async Task GetProductById_ReturnsOkResult_WhenProductExists()
        {
            // Arrange
            int productId = 1;
            var product = new Product { Id = productId, Name = "Product 1" };
            _repositoryMock.Setup(repo => repo.GetProductById(productId)).ReturnsAsync(product);

            // Act
            var result = await _controller.Get(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(productId, returnValue.Id);
        }

        [Fact(DisplayName = "Given a valid RegisterProductDTO to add a new product, When the Post endpoint is called, Then it should add the product and return an Ok result")]
        public async Task AddProduct_ReturnsOkResult_WhenProductIsAdded()
        {
            // Arrange
            var registerProductDTO = new RegisterProductDTO
            {
                Name = "Orange juice",
                Description = "pure juice",
            };

            _repositoryMock.Setup(repo => repo.Add(It.IsAny<Product>())).Verifiable();
            _repositoryMock.Setup(repo => repo.Save());

            // Act
            var result = _controller.Post(registerProductDTO);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            _repositoryMock.Verify(r => r.Add(It.IsAny<Product>()), Times.Once);
            _repositoryMock.Verify(r => r.Save(), Times.Once);
        }
    }
}
