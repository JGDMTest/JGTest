using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Calculates GiftAid for a donation amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>A gift aid response object containing the donation and gift aid amount</returns>
        /// <response code="200">Returns the git aid response object</response>
        /// <response code="400">If the amount is not a value between 2 and 100,000</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
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
