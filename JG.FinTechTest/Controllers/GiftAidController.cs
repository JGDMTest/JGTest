using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JG.FinTechTest.Controllers
{
    [Route("api/giftaid")]
    [ApiController]
    public class GiftAidController : ControllerBase
    {
        private const decimal MinimumValue = 2;
        private const decimal MaximumValue = 100000;
        private IGiftAidCalculator _giftAidCalculator;

        public GiftAidController(IGiftAidCalculator giftAidCalculator)
        {
            _giftAidCalculator = giftAidCalculator;
        }

        [HttpGet]
        public ActionResult<GiftAidResponse> GiftAid(decimal amount)
        {
            if (amount < MinimumValue || amount > MaximumValue)
            {
                return BadRequest("amount should be between £2 and £100,000");
            }
            var giftAidResult = _giftAidCalculator.CalculateGiftAid(amount);
            return new GiftAidResponse
            {
                DonationAmount = amount,
                GiftAidAmount = giftAidResult
            };
        }
    }
}
