
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
        public ActionResult<string> Healthy()
        {
            return "Healthy";
        }

        [HttpGet]
        public ActionResult<string> HealthyDb()
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