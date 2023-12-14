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
        public async Task Index_ReturnsAViewResult_WithAListProducts()
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