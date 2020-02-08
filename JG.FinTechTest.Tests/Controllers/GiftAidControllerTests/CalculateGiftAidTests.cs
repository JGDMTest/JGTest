using FluentAssertions;
using JG.FinTechTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace JG.FinTechTest.Tests.Controllers.GiftAidControllerTests
{
    public class CalculateGiftAidTests : GiftAidControllerTestBase
    {
        [Test]
        public void CalculateGiftAid_ShouldReturnResultFromGiftAidCalculator()
        {
            //Arrange
            GiftAidCalculator.CalculateGiftAid(100).Returns(20);

            //Act
            var giftAidResponse = GiftAidController.CalculateGiftAid(100).Value;

            //Assert
            giftAidResponse.GiftAidAmount.Should().Be(20);
            giftAidResponse.DonationAmount.Should().Be(100);

        }

        [Test]
        public void DonationUnderMinimumValue_ShouldReturnBadRequest()
        {
            //Act
            var giftAidResponse = GiftAidController.CalculateGiftAid(1.99m).Result;

            //Assert
            giftAidResponse.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void DonationOverMaximumValue_ShouldReturnBadRequest()
        {
            //Act
            var giftAidResponse = GiftAidController.CalculateGiftAid(100000.01m).Result;

            //Assert
            giftAidResponse.Should().BeOfType<BadRequestObjectResult>();
        }

    }
}