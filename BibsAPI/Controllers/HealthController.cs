
using Microsoft.AspNetCore.Mvc;

namespace MyBibsAPI
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HealthController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public HealthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Health
        [HttpGet]
        public ActionResult<string> HealthCheck()
        {
            return "Healthy";
        }

        [HttpGet]
        public ActionResult<string> DbHealthCheck()
        {
            var connected = _dbContext.Database.CanConnect();

            if (connected)
            {
                return "Healthy";
            }
            else
            {
                return "Unhealthy";
            }
        }
    }
}