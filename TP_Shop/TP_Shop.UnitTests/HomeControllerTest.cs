using Microsoft.AspNetCore.Mvc;
using Moq;
using TP_Shop.Controllers;
using TP_Shop.DataAccess.Entities;
using TP_Shop.DataAccess.Interfaceses;
using TP_Shop.Models;

namespace TP_Shop.UnitTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListProducts()
        {
            // Arrange
            string promoCode = "";

            var mockProductRepo = new Mock<IProductRepository>();
            mockProductRepo.Setup(repo => repo.GetByPromoCode(promoCode))
                .Returns(GetTestProducts());

            var mockPurchaseRepo = new Mock<IPurchaseRepository>();

            var controller = new HomeController(mockProductRepo.Object, mockPurchaseRepo.Object);

            // Act
            var result = controller.Index(promoCode);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void BuyGet_ReturnsAViewResult_WithProductId()
        {
            // Arrange
            var productId = 2;
            var mockProductRepo = new Mock<IProductRepository>();
            var mockPurchaseRepo = new Mock<IPurchaseRepository>();

            var controller = new HomeController(mockProductRepo.Object, mockPurchaseRepo.Object);

            // Act
            var result = controller.Buy(productId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<int>(
                viewResult.ViewData["ProductId"]);
            Assert.Equal(productId, model);
        }

        [Fact]
        public void BuyPost_ReturnBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            string promoCode = "";

            var mockProductRepo = new Mock<IProductRepository>();
            mockProductRepo.Setup(repo => repo.GetByPromoCode(promoCode))
                .Returns(GetTestProducts());

            var mockPurchaseRepo = new Mock<IPurchaseRepository>();

            var controller = new HomeController(mockProductRepo.Object, mockPurchaseRepo.Object);
            controller.ModelState.AddModelError("Address", "Required");

            var purchase = new PurchaseViewModel()
            {
                Person = "Test",
            };

            // Act
            var result = controller.Buy(purchase);


            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void BuyPost_ReturnARedirectAndAddPurchase_WhenModelStateIsValid()
        {
            // Arrange
            var mockProductRepo = new Mock<IProductRepository>();

            var mockPurchaseRepo = new Mock<IPurchaseRepository>();
            mockPurchaseRepo.Setup(repo => repo.Create(It.IsAny<Purchase>()))
                .Verifiable();

            var controller = new HomeController(mockProductRepo.Object, mockPurchaseRepo.Object);

            var purchase = new PurchaseViewModel()
            {
                Person = "Тест",
                Address = "Улица"
            };

            // Act
            var result = controller.Buy(purchase);


            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockPurchaseRepo.Verify();
        }

        private List<Product> GetTestProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Test",
                    Price = 10000
                },
                new Product
                {
                    Id = 2,
                    Name = "Test2",
                    Price = 8000
                }
            };
            return products;
        }
    }
}