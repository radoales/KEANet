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

        [Theory]
        [ClassData(typeof(SetUps.BuyTestData))]
        public void BasketWithItems_ShouldReturn_String(Product a, Product b, Product c)
        {
            //Arange
            var service = MockPurchaseService();
            var products = new List<Product>() { a, b, c };
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
