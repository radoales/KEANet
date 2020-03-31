namespace KEANet.Tests
{
    using Xunit;
    using FluentAssertions;
    using static SetUps.Mocks;
    using System;
    using System.Collections.Generic;

    public class AddInternetConnectionTest
    {
        [Fact]
        public void PassTrue_ShouldReturn_Int()
        {
            //Arange
            var service = MockPurchaseService();

            //Act
           var result = service.AddInternetConnection(true);

            //Assert
            result
                .Should()
                .Be(200);
        }
        [Fact]
        public void PassFalse_ShouldReturn_Int()
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            var result = service.AddInternetConnection(false);

            //Assert
            result
                .Should()
                .Be(0);
        }
        [Fact]
        public void PassFalse_ShouldThrow_ArgumentException()
        {
            //Arange
            var service = MockPurchaseServiceWithEmptyDatabase();

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => service.AddInternetConnection(true));
        }
    }
}
