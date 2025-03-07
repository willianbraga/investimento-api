using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Investimento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;

        public HealthController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet("check")]
        public async Task<IActionResult> Check()
        {
            var healthReport = await _healthCheckService.CheckHealthAsync();

            if (healthReport.Status == HealthStatus.Healthy)
            {
                return Ok(new { status = "Healthy", details = healthReport });
            }
            else
            {
                return StatusCode(503, new { status = "Unhealthy", details = healthReport });
            }
        }
    }
}
