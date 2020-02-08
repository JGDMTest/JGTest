using System;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace JG.FinTechTest.Tests.Controllers.GiftAidControllerTests
{
    public class PersistDonorInformationTests : GiftAidControllerTestBase
    {
        [Test]
        public void ValidRequest_ShouldReturnResponseFromRepository()
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
            (response.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.Created);
            response.Value.Should().BeEquivalentTo(persistInformationResponse);
        }

        [Test]
        public void UserAlreadyExists_ShouldReturnBadRequest()
        {
            //Arrange
            DonorRepository.PersistDonorInformation("Error", "400", 20).Throws(new UserAlreadyExistsException());

            //Act
            var response = GiftAidController.PersistDonorInformation("Error", "400", 20);

            //Assert
            response.Result.Should().BeOfType<BadRequestObjectResult>();

        }
    }
}