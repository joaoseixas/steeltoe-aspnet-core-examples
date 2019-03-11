using Microsoft.AspNetCore.Mvc;

namespace exemplo_api_a.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActuatorController : ControllerBase
    {
        public object Get()
        {
            return @"
            {
""_links"": {
""self"": {
""href"": ""http://localhost:5001/actuator"",
""templated"": false
},
""health"": {
""href"": ""http://localhost:5001/actuator/health"",
""templated"": false
},
""health-component"": {
""href"": ""http://localhost:5001/actuator/health/{component}"",
""templated"": true
},
""health-component-instance"": {
""href"": ""http://localhost:5001/actuator/health/{component}/{instance}"",
""templated"": true
},
""env-toMatch"": {
""href"": ""http://localhost:5001/actuator/env/{toMatch}"",
""templated"": true
},
""env"": {
""href"": ""http://localhost:5001/actuator/env"",
""templated"": false
},
""info"": {
""href"": ""http://localhost:5001/actuator/info"",
""templated"": false
},
""loggers"": {
""href"": ""http://localhost:5001/actuator/loggers"",
""templated"": false
},
""loggers-name"": {
""href"": ""http://localhost:5001/actuator/loggers/{name}"",
""templated"": true
},
""metrics-requiredMetricName"": {
""href"": ""http://localhost:5001/actuator/metrics/{requiredMetricName}"",
""templated"": true
},
""metrics"": {
""href"": ""http://localhost:5001/actuator/metrics"",
""templated"": false
},
""refresh"": {
""href"": ""http://localhost:5001/actuator/refresh"",
""templated"": false
}
}
}

            ";
        }
    }
}