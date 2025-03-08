using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentOrBuy.Home.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("App is running");
        }
    }
}
