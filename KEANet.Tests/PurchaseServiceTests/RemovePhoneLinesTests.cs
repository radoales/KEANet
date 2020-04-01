namespace KEANet.Tests.PurchaseServiceTests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;
    using static SetUps.Mocks;

    public class RemovePhoneLinesTests
    {
        [Theory]
        [InlineData("Product not found")]
        public void PhoneLineNotInDatabase_ShouldThrow_ArgumentException(string expexted)
        {
            //Arange
            var service = MockPurchaseServiceWithEmptyDatabase();

            //Act
            Action result = () => service.RemovePhoneLines();

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }

        [Theory]
        [InlineData("There are no lines to remove")]
        public void NoPhoneLinesInBasket_ShouldThrow_ArgumentException(string expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            Action result = () => service.RemovePhoneLines();

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }

        [Theory]
        [InlineData(0)]
        public void RemovePhoneLine_ShouldReturn_Zero(int expexted)
        {
            //Arange
            var service = MockPurchaseService();
            service.AddPhoneLines();

            //Act
            var result = service.RemovePhoneLines();

            //Assert
            result
                .Should()
                .Be(expexted);
        }
    }
}
