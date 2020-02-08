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
        private readonly IGiftAidCalculator _giftAidCalculator;
        private IDonorRepository _donorRepository;

        public GiftAidController(IGiftAidCalculator giftAidCalculator, IDonorRepository donorRepository)
        {
            _giftAidCalculator = giftAidCalculator;
            _donorRepository = donorRepository;
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
        public ActionResult<GiftAidResponse> CalculateGiftAid(decimal amount)
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

        /// <summary>
        /// Calculates GiftAid for a donation amount
        /// </summary>
        /// <param name="postCode">the donor's postcode</param>
        /// <param name="amount">the donation amount</param>
        /// <param name="name">the donors name</param>
        /// <returns>A gift aid response object containing the donation and gift aid amount</returns>
        /// <response code="201">Returns the id of the newly created object and the donation amount</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public ActionResult<PersistInformationResponse> PersistDonorInformation(string name, string postCode, decimal amount)
        {
           return new PersistInformationResponse();
        }
    }
}
