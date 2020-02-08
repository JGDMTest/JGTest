using FluentAssertions;
using JG.FinTechTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace JG.FinTechTest.Tests.Controllers
{
    public class GiftAidControllerTests
    {
        private GiftAidController _giftAidController;
        private IGiftAidCalculator _giftAidCalculator;

        [SetUp]
        public void Setup()
        {
            _giftAidCalculator = Substitute.For<IGiftAidCalculator>();
            _giftAidController = new GiftAidController(_giftAidCalculator);

        }

        [Test]
        public void GiftAidController_ShouldReturnResultFromGiftAidCalculator()
        {
            //Arrange
            _giftAidCalculator.CalculateGiftAid(100).Returns(20);

            //Act
            var giftAidResponse = _giftAidController.GiftAid(100).Value;

            //Assert
            giftAidResponse.GiftAidAmount.Should().Be(20);
            giftAidResponse.DonationAmount.Should().Be(100);

        }

        [Test]
        public void DonationUnderMinimumValue_ShouldReturnBadRequest()
        {
            //Act
            var giftAidResponse = _giftAidController.GiftAid(1.99m).Result;

            //Assert
            giftAidResponse.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void DonationOverMaximumValue_ShouldReturnBadRequest()
        {
            //Act
            var giftAidResponse = _giftAidController.GiftAid(100000.01m).Result;

            //Assert
            giftAidResponse.Should().BeOfType<BadRequestObjectResult>();
        }

    }
}