namespace KEANet.Tests
{
    using Xunit;
    using FluentAssertions;
    using static SetUps.Mocks;
    using System;

    public class AddInternetConnectionTest
    {
        [Theory]
        [InlineData(false, 0)]
        public void PassFalse_ShouldReturn_0(bool input, int expexted)
        {
            //Arange
            var service = MockPurchaseService();
            service.AddInternetConnection(true);

            //Act
            var result = service.AddInternetConnection(input);

            //Assert
            result
                .Should()
                .Be(expexted);
        }
        [Theory]
        [InlineData(true, 200)]
        public void PassTrue_ShouldReturn_Int(bool input, int expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            var result = service.AddInternetConnection(input);

            //Assert
            result
                .Should()
                .Be(expexted);
        }

        [Theory]
        [InlineData(false, "There is no Internet Connection to be removed")]
        public void PassFalseWithNoInternetConnectionInBasket_ShouldThrow_ArgumentException(bool input, string expected)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            Action result = () => service.AddInternetConnection(input);

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expected);
        }

        [Theory]
        [InlineData(false, "Product not found")]
        public void MissingProductInDb_ShouldThrow_ArgumentException(bool input, string expected)
        {
            //Arange
            var service = MockPurchaseServiceWithEmptyDatabase();

            //Act
            Action result = () => service.AddInternetConnection(input);

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expected);
        }

    }
}
