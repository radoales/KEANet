namespace KEANet.Tests
{
    using Xunit;
    using FluentAssertions;
    using static SetUps.Mocks;
    using System;

    public class AddInternetConnectionTest
    {
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
        [InlineData(false, 0)]
        public void PassFalse_ShouldReturn_Int(bool input, int expexted)
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
        [InlineData(false)]
        public void PurchaseServiceWithEmptyDatabase_ShouldThrow_ArgumentException(bool input)
        {
            //Arange
            var service = MockPurchaseServiceWithEmptyDatabase();

            //Act
            Action result = () => service.AddInternetConnection(input);

            //Assert
            result
                .Should()
                .Throw<ArgumentException>();
        }
    }
}
