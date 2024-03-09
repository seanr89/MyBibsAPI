
using Microsoft.AspNetCore.Mvc;

namespace MyBibsAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        // GET: api/Health
        [HttpGet]
        public ActionResult<string> GetHealth()
        {
            return "Healthy";
        }
    }
}