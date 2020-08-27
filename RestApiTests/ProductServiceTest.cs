using Moq;
using NUnit.Framework;
using RestApiCRUDOperations.Controllers;
using RestApiCRUDOperations.Interface;
using RestApiCRUDOperations.Models;
using RestApiCRUDOperations.Services;
using System.Net;
using System.Threading.Tasks;

namespace RestApiCRUDOperationsTests
{
    public class ProductServiceTest
    {
        private IProductService _productService;
        private Mock<IProductDataAccess> _mockProductDataAccess;
        private ProductController _productController;
        [SetUp]

        public void Setup()
        {
            _mockProductDataAccess = new Mock<IProductDataAccess>();
            _productService = new ProductService(_mockProductDataAccess.Object);
            GetControllerInstance();
        }

        private void GetControllerInstance()
        {
            _productController = new ProductController(_productService);
        }

        [Test]
        public async Task GetProduct_Product_Successful_Return_Ok()
        {
            _mockProductDataAccess.Setup(m => m.GetProductById(It.IsAny<int>())).ReturnsAsync(new ProductItem
                {ProductId = 1, ProductName = "Cricket Bat", ProductPrice = 1000.99, IsProductAvailable = true});

            var result = await _productController.GetProduct(1);

            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
        }

        [Test]
        public async Task Create_Product_Successful_Return_Created()
        {
            _mockProductDataAccess.Setup(m => m.AddProduct(It.IsAny<ProductItem>())).ReturnsAsync(true);
            var product = new ProductItem
                {ProductId = 777, ProductName = "Cricket Bat", ProductPrice = 1000.99, IsProductAvailable = true};

            var result = await _productController.AddProduct(product);

            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
        }

        [Test]
        public async Task Update_Product_Successful_Return_Ok()
        {
            _mockProductDataAccess.Setup(m => m.UpdateProduct(It.IsAny<ProductItem>())).ReturnsAsync(true);
            var product = new ProductItem
                { ProductId = 777, ProductName = "Cricket Bat-1", ProductPrice = 1000.99, IsProductAvailable = true };

            var result = await _productController.UpdateProduct(product);

            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
        }

        [Test]
        public async Task Delete_Product_Successful_Return_Ok()
        {
            _mockProductDataAccess.Setup(m => m.DeleteProductById(It.IsAny<int>())).ReturnsAsync(true);

            var result = await _productController.DeleteProduct(1);

            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
        }
    }
}
