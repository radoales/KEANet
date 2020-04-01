namespace KEANet.Tests.PurchaseServiceTests
{
    using FluentAssertions;
    using KEANet.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using static SetUps.Mocks;

    public class UnSelectPhoneTests
    {
        [Theory]
        [ClassData(typeof(SetUps.SelectPhoneTestData))]
        public void PassExistingModel_ShouldReturn_CorrectSum(string input, int price)
        {
            //Arange
            var service = MockPurchaseService();
            service.basket.AddRange(
            new List<Product>()
            {
                  new Product{Id = 3, Name = "Motorola G99", Price = 800, Regularity = Regularity.once},
                  new Product{Id = 4, Name = "iPhone 99", Price = 6000, Regularity = Regularity.once},
                  new Product{Id = 5, Name = "Samsung Galaxy 99", Price = 1000, Regularity = Regularity.once},
                  new Product{Id = 6, Name = "Sony Xperia 99", Price = 900, Regularity = Regularity.once},
                  new Product{Id = 7, Name = "Huawei 99", Price = 900, Regularity = Regularity.once}
            });
            var sumOfBasketAfterRemove = service.basket.Sum(x => x.Price) - price;

            //Act
            var result = service.UnSelectPhone(input);

            //Assert
            result
                .Should()
                .Be(sumOfBasketAfterRemove);
        }

        [Theory]
        [InlineData("NonExistingPhone", "No selected model to remove")]
        public void PassNonExistingModel_ShouldThrow_ArgumentException(string input, string expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            Action result = () => service.UnSelectPhone(input);

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }

        [Theory]
        [InlineData("Motorola G99", "No such model in the basket")]
        public void PhoneModelNotInBasket_ShouldThrow_ArgumentException(string input, string expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            Action result = () => service.UnSelectPhone(input);

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }

    }
}
