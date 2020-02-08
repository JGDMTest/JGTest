using FluentAssertions;
using JG.FinTechTest.Controllers;
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
            var giftAidResponse = _giftAidController.GiftAid(100);

            //Assert
            giftAidResponse.GiftAidAmount.Should().Be(20);
            giftAidResponse.DonationAmount.Should().Be(100);



        }

    }
}