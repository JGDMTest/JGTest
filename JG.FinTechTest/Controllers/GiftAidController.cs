using Microsoft.AspNetCore.Mvc;

namespace JG.FinTechTest.Controllers
{
    [Route("api/giftaid")]
    [ApiController]
    public class GiftAidController : ControllerBase
    {
        private IGiftAidCalculator _giftAidCalculator;

        public GiftAidController(IGiftAidCalculator giftAidCalculator)
        {
            _giftAidCalculator = giftAidCalculator;
        }

        [HttpGet]
        public GiftAidResponse GiftAid(decimal amount)
        {
            var giftAidResult = _giftAidCalculator.CalculateGiftAid(amount);
            return new GiftAidResponse
            {
                DonationAmount = amount,
                GiftAidAmount = giftAidResult
            };
        }
    }
}
