using Microsoft.AspNetCore.Mvc;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [ApiController]
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(new[] { "1.0" });
        }
    }
}
