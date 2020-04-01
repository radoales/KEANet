namespace KEANet.Tests.PurchaseServiceTests
{
    using FluentAssertions;
    using KEANet.Data;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;
    using static SetUps.Mocks;

    public class BuyTests
    {
        [Theory]
        [InlineData("Please select service!")]
        public void EmptyBasket_ShouldThrow_ArgumentException(string expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            Action result = () => service.Buy();

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }

        [Fact]
        public void BasketWithItems_ShouldReturn_String()
        {
            //Arange
            var service = MockPurchaseService();
            var products = new List<Product>()
            {
                  new Product{Id = 3, Name = "Motorola G99", Price = 800, Regularity = Regularity.Once},
                  new Product{Id = 4, Name = "iPhone 99", Price = 6000, Regularity = Regularity.Once},
            };
            service.basket.AddRange(products);
            
            var buildExpected = new StringBuilder();
            foreach (var product in products)
            {
                buildExpected.Append($"{product.Name} - {product.Price} - {product.Regularity}");
                buildExpected.AppendLine();
            }

           var expected = buildExpected.ToString().Trim();

            //Act
            var result = service.Buy();

            //Assert
            result
                .Should()
                .Be(expected);
        }
    }
}
