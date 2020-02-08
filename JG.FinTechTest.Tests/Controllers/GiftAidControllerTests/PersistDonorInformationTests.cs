using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace JG.FinTechTest.Tests.Controllers.GiftAidControllerTests
{
    public class PersistDonorInformationTests : GiftAidControllerTestBase
    {
        [Test]
        public void PersistDonorInformation_ShouldReturnResponseFromRepository()
        { 
            //Arrange
            var persistInformationResponse = new PersistInformationResponse
            {
                Id = Guid.NewGuid(),
                Amount = 100
            };
            DonorRepository.PersistDonorInformation("David", "n1123", 100).Returns(persistInformationResponse);

            //Act
            var response = GiftAidController.PersistDonorInformation("David", "n1123", 100);

            //Assert
            response.Result.Should().BeEquivalentTo(persistInformationResponse);
        }
    }
}