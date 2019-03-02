using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exemplo_api_b.HealthContributors;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Common.HealthChecks;

namespace exemplo_api_b.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        // POST api/values
        [HttpPost("{status}")]
        public void Post([FromRoute] HealthStatus status)
        {
            StatusCheck.Status = status;
        }
    }
}
