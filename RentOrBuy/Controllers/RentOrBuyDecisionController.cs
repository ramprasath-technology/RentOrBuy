using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentOrBuy.Home.Business.RentOrBuyComputations;
using RentOrBuy.Home.DataModel;
using System.Net;

namespace RentOrBuy.Home.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentOrBuyDecisionController : ControllerBase
    {
        private readonly IRentOrBuyCalculator _rentOrBuyCalculator;
        public RentOrBuyDecisionController(IRentOrBuyCalculator rentOrBuyCalculator)
        {
            _rentOrBuyCalculator = rentOrBuyCalculator;
        }

        [HttpGet("rent-or-buy/v1")]
        public async Task<IActionResult> GetRentOrBuyDecision([FromBody]UserInput userInput)
        {
            try
            {
                if (userInput == null)
                {
                    return BadRequest();
                }
                var response = await _rentOrBuyCalculator.GetRentOrBuyDecision(userInput);
                return Ok(response);
            }
            catch (Exception ex)
            {
                //Log exception with details
                return new ContentResult()
                {
                    Content = $"Error occurred when processing the request",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}
