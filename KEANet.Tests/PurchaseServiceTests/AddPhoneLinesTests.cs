namespace KEANet.Tests.PurchaseServiceTests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;
    using static SetUps.Mocks;

    public class AddPhoneLinesTests
    {
        [Theory]
        [InlineData(150)]
        public void AddPhoneLine_ShouldReturn_150(int expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            var result = service.AddPhoneLines();

            //Assert
            result
                .Should()
                .Be(expexted);
        }

        [Theory]
        [InlineData("Product not found")]
        public void PhoneLineNotInDatabase_ShouldThrow_ArgumentException( string expexted)
        {
            //Arange
            var service = MockPurchaseServiceWithEmptyDatabase();

            //Act
            Action result = () => service.AddPhoneLines();

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }

        [Theory]
        [InlineData("You cannot buy more than 8 lines")]
        public void MoreThanEightLines_ShouldThrow_ArgumentException(string expexted)
        {
            //Arange
            var service = MockPurchaseService();
            for (int i = 0; i < 8; i++)
            {
                service.AddPhoneLines();
            }

            //Act
            Action result = () => service.AddPhoneLines();

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }
    }
}
