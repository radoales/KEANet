namespace KEANet.Tests.PurchaseServiceTests
{
    using FluentAssertions;
    using System;
    using Xunit;
    using static SetUps.Mocks;

    public class SelectPhoneTests
    {
        [Theory]
        [ClassData(typeof(SetUps.SelectPhoneTestData))]
        public void PassExistingModel_ShouldReturn_CorrectSum(string input, int expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            var result = service.SelectPhone(input);

            //Assert
            result
                .Should()
                .Be(expexted);
        }

        [Theory]
        [InlineData("NonExistingPhone", "No selected model to add")]
        public void PassNonExistingModel_ShouldThrow_ArgumentException(string input, string expexted)
        {
            //Arange
            var service = MockPurchaseService();

            //Act
            Action result = () => service.SelectPhone(input);

            //Assert
            result
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expexted);
        }
    }
}
