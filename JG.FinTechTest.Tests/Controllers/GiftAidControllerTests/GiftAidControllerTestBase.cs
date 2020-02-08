using JG.FinTechTest.Controllers;
using NSubstitute;
using NUnit.Framework;

namespace JG.FinTechTest.Tests.Controllers.GiftAidControllerTests
{
    public class GiftAidControllerTestBase
    {
        protected GiftAidController GiftAidController;
        protected IGiftAidCalculator GiftAidCalculator;
        protected IDonorRepository DonorRepository;

        [SetUp]
        public void Setup()
        {
            GiftAidCalculator = Substitute.For<IGiftAidCalculator>();
            DonorRepository = Substitute.For<IDonorRepository>();
            GiftAidController = new GiftAidController(GiftAidCalculator, DonorRepository);
        }

    }
}